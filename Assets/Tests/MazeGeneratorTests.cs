using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using static MazeGenerator;

public class MazeGeneratorTests
{
    private bool areMazesIdentical(List<List<MazeNode>> maze1, List<List<MazeNode>> maze2, Vector2Int mazeSize) {
        for (int y = 0; y < mazeSize.y; y++) {
            for (int x = 0; x < mazeSize.x; x++) {
                MazeNode node1 = maze1[y][x];
                MazeNode node2 = maze2[y][x];
                bool areNodesIdentical = node1.hasTopWall == node2.hasTopWall
                    && node1.hasBottomWall == node2.hasBottomWall
                    && node1.hasLeftWall == node2.hasLeftWall
                    && node1.hasRightWall == node2.hasRightWall
                    && node1.isStartNode == node2.isStartNode
                    && node1.isExitNode == node2.isExitNode;
                if (!areNodesIdentical) {
                    return false;
                }
            }
        }
        return true;
    }

    [Test]
    public void TestRandomSeed() {
        Vector2Int mazeSize = new Vector2Int(5, 5);
        MazeGenerator generator = new MazeGenerator();
        List<List<MazeNode>> generatedMaze1 = generator.GenerateMaze(new Vector2Int(5, 5), -1);
        List<List<MazeNode>> generatedMaze2 = generator.GenerateMaze(new Vector2Int(5, 5), -1);
        
        bool identical = areMazesIdentical(generatedMaze1, generatedMaze2, mazeSize);
        Assert.AreEqual(identical, false);
    }

    [Test]
    public void TestSameSeed() {
        Vector2Int mazeSize = new Vector2Int(5, 5);
        MazeGenerator generator = new MazeGenerator();
        List<List<MazeNode>> generatedMaze1 = generator.GenerateMaze(new Vector2Int(5, 5), 411);
        List<List<MazeNode>> generatedMaze2 = generator.GenerateMaze(new Vector2Int(5, 5), 411);
        
        bool identical = areMazesIdentical(generatedMaze1, generatedMaze2, mazeSize);
        Assert.AreEqual(identical, true);
    }
}
