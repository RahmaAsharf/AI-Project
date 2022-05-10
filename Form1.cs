namespace Simple_PACMAN_Game
{
    public partial class Form1 : Form
    {

        bool goup, godown, goleft, goright,isGameOver;

        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY;

        public Form1()
        {
            InitializeComponent();

            resetGame();
        }


                   //key is pressed

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = true;           
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }


            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

        }
                  //key is released
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }


            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            if (e.KeyCode ==Keys.Enter && isGameOver==true)
            {
                resetGame();
            }
        }


        private void mainGameTimer(object sender, EventArgs e)
        {
            textScore.Text = "Score: " + score;

            if (goleft == true)
            {
                Pacman.Left -= playerSpeed;
                Pacman.Image = Properties.Resources.left__1_;

            }
            if (goright == true)
            {
                Pacman.Left += playerSpeed;
                Pacman.Image = Properties.Resources.right__1_;

            }

            if (godown == true)
            {
                Pacman.Top += playerSpeed;
                Pacman.Image = Properties.Resources.down__1_;

            }
            if (goup == true)
            {
                Pacman.Top -= playerSpeed;
                Pacman.Image = Properties.Resources.up__1_;

            }
            ///عشان لما يوصل لحدود الشاشه يكمل من النحية التانيه
            if (Pacman.Left < -10)
            {
                Pacman.Left = 770;
            }

            if (Pacman.Left > 770)
            {
                Pacman.Left = -10;
            }



            if (Pacman.Top < -10)
            {
                Pacman.Top = 500;
            
            }

            if (Pacman.Top >500)
            {
                Pacman.Top = 0;

            }
                 // all controls in the form put in the x var
                 // collect coins
            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                { 
                
                    if((string)x.Tag=="coin" && x.Visible==true)
                    {
                        if(Pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;

                        }
                    }

                    if ((string)x.Tag=="wall")
                    {
                        if(Pacman.Bounds.IntersectsWith(x.Bounds))
                        {

                            gameOver("you LOSE!!");
                        }

                    }

                    if ((string)x.Tag=="ghost")
                    {
                        if (Pacman.Bounds.IntersectsWith(x.Bounds))
                        {

                            gameOver("you LOSE!");
                        }
                        if (pinkGhost.Bounds.IntersectsWith(x.Bounds))
                        {
                            pinkGhostX = -pinkGhostX;
                        }

                    }

                }

            }

            // moving ghosts
            redGhost.Left += redGhostSpeed;

            if (redGhost.Bounds.IntersectsWith(pictureBox1.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowGhost.Left -= yellowGhostSpeed;
            if (yellowGhost.Bounds.IntersectsWith(pictureBox18.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox19.Bounds))
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }

            pinkGhost.Left -= pinkGhostX;
            pinkGhost.Top -= pinkGhostY;

            if (pinkGhost.Top<0||pinkGhost.Top>500)
            {
                pinkGhostY = -pinkGhostY;

            }

            if(pinkGhost.Left < 0 || pinkGhost.Left > 770)
            {
                pinkGhostX = -pinkGhostX;

            }





            if (score == 87)
            {
                gameOver("you WIN!");

            }


        }

        private void resetGame() 
        {
            textScore.Text = "Score: =0";
            score = 0;

            redGhostSpeed = 5;
            yellowGhostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            playerSpeed = 8;

            isGameOver = false;
            Pacman.Left = 72;
            Pacman.Top = 75;

            redGhost.Left = 102;
            redGhost.Top = 371;

            yellowGhost.Left = 487;
            yellowGhost.Top = 437;

            pinkGhost.Left = 487;
            pinkGhost.Top = 66;

            foreach (Control x in this.Controls)
            { 
                if(x is PictureBox)
                {

                    x.Visible = true;
                }
            
            
            
            }

            gameTimer.Start();
        
        }
        private void gameOver(string message)
        { 
            isGameOver=true;
            gameTimer.Stop();

            textScore.Text +="score:"+score + Environment.NewLine + message;
        }

       
    }
}