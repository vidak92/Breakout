
public static class LevelData
{
    public static char[][,] Levels = new char[][,]
    {
        // level 0
        new char[BrickGrid.MaxRows, BrickGrid.MaxCols]
        {
            { 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
//            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
//            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
//            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
//            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
            { 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E' },
            { 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E' },
            { 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E' },
        },

        // level 1
        new char[BrickGrid.MaxRows, BrickGrid.MaxCols]
        {
            { 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E' },
            { 'E', 'E', 'E', 'B', 'B', 'E', 'E', 'E' },
            { 'E', 'E', 'B', 'B', 'B', 'B', 'E', 'E' },
            { 'E', 'B', 'B', 'B', 'B', 'B', 'B', 'E' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'B' },
            { 'E', 'B', 'B', 'B', 'B', 'B', 'B', 'E' },
            { 'E', 'E', 'B', 'B', 'B', 'B', 'E', 'E' },
        },

        // level 2
        new char[BrickGrid.MaxRows, BrickGrid.MaxCols]
        {
            { 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E' },
            { 'B', 'E', 'E', 'E', 'E', 'E', 'E', 'E' },
            { 'B', 'B', 'E', 'E', 'E', 'E', 'E', 'E' },
            { 'B', 'B', 'B', 'E', 'E', 'E', 'E', 'E' },
            { 'B', 'B', 'B', 'B', 'E', 'E', 'E', 'E' },
            { 'B', 'B', 'B', 'B', 'B', 'E', 'E', 'E' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'E', 'E' },
            { 'B', 'B', 'B', 'B', 'B', 'B', 'B', 'E' },
        },

        // level 3
        new char[BrickGrid.MaxRows, BrickGrid.MaxCols]
        {
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
            { 'B', 'B', 'E', 'B', 'B', 'E', 'B', 'B' },
        }
    };
}
