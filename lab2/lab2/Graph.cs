using System;
using System.Collections.Generic;

namespace lab2
{
    class Graph
    {
        private List<Arc> _arcList;
        private List<Vertex> _vertexList;
        private int _maxVertex = 0;

        public Graph(List<Arc> arcList, List<Vertex> vertexList)
        {
            _arcList = arcList;
            _vertexList = vertexList;

            for (int i = 0; i < arcList.Count; i++)
            {
                if (arcList[i].Vertex1Mark > _maxVertex)
                {
                    _maxVertex = arcList[i].Vertex1Mark;
                }

                if (arcList[i].Vertex2Mark > _maxVertex)
                {
                    _maxVertex = arcList[i].Vertex2Mark;
                }
            }
        }

        public int FIRST(int v)
        {
            for (int i = 0; i < _arcList.Count; i++)
            {
                if (_arcList[i].Vertex1Mark == v)
                {
                    return _arcList[i].Vertex2Mark;
                }

                if (_arcList[i].Vertex2Mark == v)
                {
                    return _arcList[i].Vertex1Mark;
                }
            }

            return 0;
        }

        public int NEXT(int v, int i)
        {
            if ((i + 1) <= _maxVertex)
            {
                for (int j = 0; j < _arcList.Count; j++)
                {
                    if ((_arcList[j].Vertex1Mark == i + 1) && (_arcList[j].Vertex2Mark == v))
                    {
                        return _arcList[j].Vertex1Mark;
                    }

                    if ((_arcList[j].Vertex2Mark == i + 1) && (_arcList[j].Vertex1Mark == v))
                    {
                        return _arcList[j].Vertex2Mark;
                    }
                }
            }

            return 0;
        }

        public int VERTEX(int v, int i)
        {
            int index = -1;

            for (int j = 0; j < _arcList.Count; j++)
            {

                if (_arcList[j].Vertex1Mark == v)
                {
                    index++;

                    if (index == i)
                    {
                        return _arcList[j].Vertex2Mark;
                    }
                }

                if (_arcList[j].Vertex2Mark == v)
                {
                    index++;

                    if (index == i)
                    {
                        return _arcList[j].Vertex1Mark;
                    }
                }
            }

            return -1;
        }

        public void ADD_V(string name, int mark)
        {
            _vertexList.Add(new Vertex(name, mark));
        }

        public void ADD_E(int v, int w, int c)
        {
            //ссылки на уже существующие вершины (становятся таковыми после поиска)
            Vertex vertex1 = null;
            Vertex vertex2 = null;

            //поиск вершин в массиве вершин, между которыми будет проходить дуга
            for (int i = 0; i < _vertexList.Count; i++)
            {
                if (_vertexList[i].mark == v)
                {
                    vertex1 = _vertexList[i];
                }

                if (_vertexList[i].mark == w)
                {
                    vertex2 = _vertexList[i];
                }
            }

            _arcList.Add(new Arc(vertex1, vertex2, c));
        }

        public void DEL_V(string name)
        {
            //поиск 
            for (int i = 0; i < _vertexList.Count; i++)
            {
                if (_vertexList[i].name == name)
                {
                    _vertexList.RemoveAt(i);
                    return;
                }
            }

            for (int i = 0; i < _arcList.Count; i++)
            {
                if ((_arcList[i].Vertex1Name == name) && (_arcList[i].Vertex2Name == name))
                {
                    _arcList.RemoveAt(i);
                    return;
                }
            }
        }

        public void DEL_E(int v, int w)
        {
            for (int i = 0; i < _arcList.Count; i++)
            {
                if ((_arcList[i].Vertex1Mark == v) && (_arcList[i].Vertex2Mark == w))
                {
                    _arcList.RemoveAt(i);
                    return;
                }
            }
        }

        public void EDID_V(string name, int mark)
        {
            for (int i = 0; i < _vertexList.Count; i++)
            {
                if (_vertexList[i].name == name)
                {
                    _vertexList[i].mark = mark;
                    return;
                }
            }
        }

        public void EDID_E(int v, int w, int c)
        {
            for (int i = 0; i < _arcList.Count; i++)
            {
                if ((_arcList[i].Vertex1Mark == v) && (_arcList[i].Vertex2Mark == w))
                {
                    _arcList[i].arcWeight = c;
                    return;
                }
            }
        }

        public void FindAllPaths(int from, int to)
        {
            List<int> path = new List<int>();
            path.Add(from);

            FindArcsFromVertex(path, from, to);
        }

        private void PrintPath(List<int> path)
        {
            //создаём строку выхода, изначально заполненную первым элементом пути
            string output = path[0].ToString();

            //КРАСИВО заполняем строку элементами пути
            for (int i = 1; i < path.Count; i++)
            {
                output += " -> " + path[i].ToString();
            }

            Console.WriteLine(output);
        }

        private void FindAllPathsRecursion(List<int> path, int from, int target)
        {
            //вызываем конструктор для копирования прошлого пути
            List<int> newPath = new List<int>(path);

            //добавляем в путь текущую (новую) вершину
            newPath.Add(from);

            //проверка: является ли текущая вершина искомой
            if (from == target)
            {
                PrintPath(newPath);
                return;
            }

            //вызов рекурсии
            FindArcsFromVertex(newPath, from, target);
        }

        private void FindArcsFromVertex(List<int> path, int from, int target)
        {
            //перебираем список дуг
            for (int i = 0; i < _arcList.Count; i++)
            {
                //находим все исходящие дуги
                if (_arcList[i].Vertex1Mark == from)
                {
                    //вызываем для исходящих дуг рекурсию
                    FindAllPathsRecursion(path, _arcList[i].Vertex2Mark, target);
                }
            }
        }
    }
}
