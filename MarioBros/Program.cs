using System;

namespace MarioBros
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MarioBrosGame())
                game.Run();
        }
    }
}
