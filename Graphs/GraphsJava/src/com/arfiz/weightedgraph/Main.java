package com.arfiz.weightedgraph;

public class Main {
    public static void main(String[] args) {
        var graph = new WeightedGraph();
        graph.addNode("A");
        graph.addNode("B");
        graph.addNode("C");
        graph.addEdge("A", "B", 1);
        graph.addEdge("B", "C", 2);
        graph.addEdge("C", "A", 10);
        //var path = graph.getShortestPath("A", "C");


        System.out.println(graph.hasCycle());
    }
}
