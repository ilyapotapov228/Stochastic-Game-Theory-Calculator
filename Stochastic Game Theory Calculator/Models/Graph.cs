using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stochastic_Game_Theory_Calculator.Models
{
    public class Graph
    {
        public class Node
        {
            public string NodeID { get; set; }
            public bool isTerminal { get; set; }

            public float[] payoffs = new float[2];

            public Player owner { get; set; }
            public List<string> connectedNodes { get; set; }
        }
        public class Player
        {
            public string name { get; set; }
            public List<string> Nodes { get; set; }
        }

        public static Node[] currentGraph;

        public float X { get; set; } = 50;
        public float Y { get; set; } = 50;

        public static Node[] defaultGraph()
        {
            Player player1 = new Player();
            player1.name = "Player 1";
            Player player2 = new Player();
            player2.name = "Player 2";
            Node nodeA = new Node();
            nodeA.NodeID = "1";
            nodeA.isTerminal = false;
            nodeA.owner = player1;
            Node nodeB = new Node();
            nodeB.NodeID = "2";
            nodeB.isTerminal = true;
            nodeB.payoffs = new float[] { 3, 2 };
            nodeA.connectedNodes = new List<string> { nodeB.NodeID };
            Node nodeC = new Node();
            nodeC.NodeID = "3";
            nodeC.isTerminal = false;
            nodeC.owner = player2;
            nodeC.connectedNodes = new List<string> { nodeA.NodeID };
            Node nodeD = new Node();
            nodeD.NodeID = "4";
            nodeD.isTerminal = true;
            nodeD.payoffs = new float[] { 1, 4 };
            nodeD.connectedNodes = new List<string> { nodeC.NodeID };
            Node nodeE = new Node();
            nodeE.NodeID = "5";
            nodeE.isTerminal = true;
            nodeE.payoffs = new float[] { 0, 0 };
            nodeE.connectedNodes = new List<string> { nodeC.NodeID };
            return (currentGraph = new Node[] { nodeA, nodeB, nodeC, nodeD, nodeE });
        }
    }
}
