using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using static LevelStoreTests;

public class LevelStoreTests
{
    [Test]
    public void TestCanLoadAllLevels() {
        int numTotalLevels = 20;
        for (int i = 0; i < numTotalLevels; i++) {
            Level level = LevelStore.loadLevel(i);
            Assert.That(level.timeLimit > 0, "Level should have loaded!");
        }
    }
}
