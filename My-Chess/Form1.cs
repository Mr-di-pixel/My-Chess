using Microsoft.VisualBasic.ApplicationServices;

namespace My_Chess
{
    public partial class Form1 : Form
    {
        public Image chessSprites;
        public int[,] map = new int[8, 8]
        {
            {15,14,13,12,11,13,14,15},
            {16,16,16,16,16,16,16,16},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {26,26,26,26,26,26,26,26},
            {25,24,23,22,21,23,24,25},
        };
        public Form1()
        {
            InitializeComponent();

            chessSprites = new Bitmap("C:\\Users\\mrdi9\\source\\repos\\My-Chess\\My-Chess\\chess.png");
           
          //  button1.BackgroundImage = part;

            Init();
        }
        public void Init()
        {
          CreateMap();
        }
        public void CreateMap()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++) 
                { 
                    Button butt=new Button();
                    butt.Size = new Size(50,50);
                    butt.Location = new Point (y * 50, x * 50);
                    switch (map[x, y]/10)
                    {
                        case 1:
                            Image part = new Bitmap(50, 50);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[x,y]%10-1), 0, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part;
                            break;
                            case 2:
                            Image part1 = new Bitmap(50, 50);
                            Graphics g1 = Graphics.FromImage(part1);
                            g1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[x, y] % 10-1), 150, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part1;
                            break;
                    }
                    this.Controls.Add(butt);
                }

            }
        }
    }
}
