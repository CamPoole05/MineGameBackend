using NUnit.Framework;

[TestFixture]
public class MineGameTests
{
    [Test]
    public void GridSizeTest3x3()
    {
        string[,] grid = { { "-", "-", "-" }, { "-", "-", "-" }, { "P", "-", "-" } };
        Grid createdGrid = new Grid(3, 3);
        UI.printGrid(createdGrid.GetGrid());
        Assert.That(createdGrid.GetGrid(), Is.EqualTo(grid));
    }

    [Test]
    public void GridSizeTest5x3()
    {
        string[,] grid = { { "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-" }, { "P", "-", "-", "-", "-" } };
        Grid createdGrid = new Grid(5, 3);
        UI.printGrid(createdGrid.GetGrid());
        Assert.That(createdGrid.GetGrid(), Is.EqualTo(grid));
    }
    [Test]
    public void MovePlayerUp()
    {
        string[,] movedGrid = { { "-", "-", "-", "-", "-" }, { "P", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-" } };
        Grid createdGrid = new Grid(5, 3);
        int newPlayerX = createdGrid.playerX;
        int newPlayerY = createdGrid.playerY - 1;
        createdGrid.MovePlayer(newPlayerX, newPlayerY);
        Assert.That(createdGrid.GetGrid(), Is.EqualTo(movedGrid));
    }
    [Test]
    public void MovePlayerRight()
    {
        string[,] movedGrid = { { "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-" }, { "-", "P", "-", "-", "-" } };
        Grid createdGrid = new Grid(5, 3);
        int newPlayerX = createdGrid.playerX+1;
        int newPlayerY = createdGrid.playerY;
        createdGrid.MovePlayer(newPlayerX, newPlayerY);
        Assert.That(createdGrid.GetGrid(), Is.EqualTo(movedGrid));
    }
    [Test]
    public void CantMovePlayerLeft()
    {
        string[,] movedGrid = { { "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-" }, { "P", "-", "-", "-", "-" } };
        Grid createdGrid = new Grid(5, 3);
        int newPlayerX = createdGrid.playerX - 1;
        int newPlayerY = createdGrid.playerY;
        bool moved = createdGrid.MovePlayer(newPlayerX, newPlayerY);
        Assert.Multiple(() =>
        {
            Assert.That(createdGrid.GetGrid(), Is.EqualTo(movedGrid));
            Assert.That(moved, Is.EqualTo(moved));
        });
    }
    [Test]
    public void CantMovePlayerDown()
    {
        string[,] movedGrid = { { "-", "-", "-", "-", "-" }, { "-", "-", "-", "-", "-" }, { "P", "-", "-", "-", "-" } };
        Grid createdGrid = new Grid(5, 3);
        int newPlayerX = createdGrid.playerX;
        int newPlayerY = createdGrid.playerY + 1;
        bool moved = createdGrid.MovePlayer(newPlayerX, newPlayerY);
        
        Assert.Multiple(() =>
        {
            Assert.That(createdGrid.GetGrid(), Is.EqualTo(movedGrid));
            Assert.That(moved, Is.EqualTo(moved));
        });
    }
}