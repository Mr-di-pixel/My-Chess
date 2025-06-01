using System.Diagnostics.Eventing.Reader;
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
        public int currPlayer;
        public Button prevButton;
        public bool isMoving = false;
        public Form1()
        {
            InitializeComponent();

            chessSprites = new Bitmap("C:\\Users\\mrdi9\\source\\repos\\My-Chess\\My-Chess\\chess.png");

            //  button1.BackgroundImage = part;

            Init();
        }
        public void Init()
        {
            map = new int[8, 8]
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
            InitializeComponent();

            currPlayer = 1;
            CreateMap();
        }
        public void CreateMap()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Button butt = new Button();
                    butt.Size = new Size(50, 50);
                    butt.Location = new Point(y * 50, x * 50);
                    switch (map[x, y] / 10)
                    {
                        case 1:
                            Image part = new Bitmap(50, 50);
                            Graphics g = Graphics.FromImage(part);
                            g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[x, y] % 10 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part;
                            break;
                        case 2:
                            Image part1 = new Bitmap(50, 50);
                            Graphics g1 = Graphics.FromImage(part1);
                            g1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[x, y] % 10 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                            butt.BackgroundImage = part1;
                            break;
                    }
                    butt.Click += new EventHandler(OnFigurePress);
                    this.Controls.Add(butt);
                }
            }
        }
        public void OnFigurePress(object sender, EventArgs e)
        {
            if (prevButton != null)

                prevButton.BackColor = Color.White;

            Button pressedButton = sender as Button;
            if (map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] != 0 && map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] / 10 == currPlayer)
            {
                pressedButton.BackColor = Color.Red;
                isMoving = true;
            }
            else
            {
                if (isMoving)
                {
                    int temp = map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50];
                    map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = map[prevButton.Location.Y / 50, prevButton.Location.X / 50];
                    map[prevButton.Location.Y / 50, prevButton.Location.X / 50] = temp;
                    pressedButton.BackgroundImage = prevButton.BackgroundImage;
                    prevButton.BackgroundImage = null;
                    isMoving = false;
                    SwithPlayer();
                }
            }
            prevButton = pressedButton;
        }
        public void SwithPlayer()
        {
            if (currPlayer == 1)
            {
                currPlayer = 2;
            }
            else
            {
                currPlayer = 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            Init();
        }
    }
}
