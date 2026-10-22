namespace tic_toc_toe
{
    public class Player
    {
        public struct PlayerFigureType
        {
            public static string First_Player = "/circle.png";
            public static string Second_Player = "/cross.png";
        }

        public string FigureType { get; set; }
        public List<byte> CheckedBoxes { get; set; }

        public Player()
        {
            CheckedBoxes = new List<byte>();
            FigureType = "";
        }

        public void ClearData ()
        {
            CheckedBoxes?.Clear();
            FigureType = "";
        }
    }
}
