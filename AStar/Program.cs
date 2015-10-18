using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar
{
    class Program
    {
        static void Main(string[] args)
        {
			//地图
            matrix Matrix = new matrix(7, 3);
			//开始点
            Node startNode = new Node(2,2,0,new Node());
			//结束点
            Node endNode = new Node(6, 2, 0, new Node());
			//阻挡点
            Node obstalNode1 = new Node(4, 1, 0, new Node());
            Node obstalNode2 = new Node(4, 2, 0, new Node());
            Node obstalNode3 = new Node(4, 3, 0, new Node());
            Dictionary<string, Node> obstalDic = new Dictionary<string,Node>();
            obstalDic.Add(obstalNode1.getKey(), obstalNode1);
            obstalDic.Add(obstalNode2.getKey(), obstalNode1);
            obstalDic.Add(obstalNode3.getKey(), obstalNode1);
            Astar astar = new Astar(startNode, endNode, Matrix, obstalDic);
            astar.AStar();
            astar.getShortCutRoute();
            Console.Read();
        }
    }
}
