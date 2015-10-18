using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AStar
{
    class Node
    {
        private int x, y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private Node Father;
        private int G;
        public Node()
        {
        }
        public Node(int x, int y, int g, Node father)
        {
            this.x = x;
            this.y = y;
            this.G = g;
            this.Father = father;
        }
        public int getG()
        {
            
            G = (((x - Father.x) * (y - Father.y) == 0) ? 10 : 14) + Father.G;
            return G;
        }

        public int getG(Node from)
        {

            G = (((x - from.x) * (y - from.y) == 0) ? 10 : 14) + from.G;
            return G;
        }

        private int ManHaTen(Node me, Node endNode)
        {
            return (System.Math.Abs(endNode.x - me.x) + System.Math.Abs(endNode.y - me.y)) * 10;
        }

        public int getH(Node endNode)
        {
            return this.ManHaTen(this, endNode);
        }

        public int getF(Node endNode)
        {
            int tem = this.getG() + this.getH(endNode);
            return tem;
        }

        public void setFather(Node father)
        {
            this.Father = father;
            this.getG();
        }

        public Node getFather()
        {
            return this.Father;
        }

        public string getKey()
        {
            return "(" + x.ToString() + "." + y.ToString() + ")";
        }

        public void showShortCutRout()
        {
            Console.WriteLine("(" + this.x.ToString() + "," + this.y.ToString() + ")" + " ");
            try
            {
                this.Father.showShortCutRout();
            }
            catch (Exception)
            {
                
                return;
            }
           
        }
            
    }
}
