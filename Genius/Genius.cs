using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Media;
using System.IO;

// Group: 
// Vinicius Milani Rodrigues de Freitas - 243670 - vmrfreitas@inf.ufrgs.br
// Denyson Jürgen Mendes Grellert - 243676 - djmgrellert@inf.ufrgs.br
// INF01120 - TÉCNICAS DE CONSTRUÇÃO DE PROGRAMAS
// Teacher: Marcelo Soares Pimenta 

namespace Genius
{
    public enum B_Colors
    {
        Blue,
        Yellow,
        Green,
        Red
    };

    public partial class Genius : Form
    {
        Gamer gamer = new Gamer();
        AI ai = new AI(); //ai stands for artificial intelligence
        public BinaryFile binary_file = new BinaryFile();

        public Genius()
        {
            InitializeComponent(); //generated automaticaly by VS (visual studio), don't delete
        }

        protected void Start_game()
        {
            Start_button.Enabled = false;
            timerAI.Enabled = false;

            binary_file.open_file(this);
            binary_file.show_highscore(this);


            binary_file.seek_file_beggining();
            gamer.highscore = binary_file.read_file();
            binary_file.seek_file_beggining();

            gamer.show_score(this);

            ai.new_shine(this);
        }

        public void Button_action(PictureBox button)
        {

            if(button == Blue_button)
            {
                button.Image = Properties.Resources.light_blue; //change the color of button and play the song

                play_song(B_Colors.Blue);
            }
            else if(button == Yellow_button)
            {
                button.Image = Properties.Resources.light_yellow;

                play_song(B_Colors.Yellow);
            }
            else if (button == Green_button)
            {
                button.Image = Properties.Resources.light_green;

                play_song(B_Colors.Green);
            }
            else if (button == Red_button)
            {
                button.Image = Properties.Resources.light_red;

                play_song(B_Colors.Red);
            }
    
        }

      

        //Play correspondent button song
        public void play_song(B_Colors color_button)
        {
            switch (color_button)//each button_color has its own song
            {
                case B_Colors.Blue:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.yellow); //properies.resource allow miss the song file
                        player.Load();
                        player.Play();
                        break;
                    }
                case B_Colors.Yellow:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.blue);
                        player.Load();
                        player.Play();
                        break;
                    }
                case B_Colors.Green:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.green);
                        player.Load();
                        player.Play();
                        break;
                    }
                case B_Colors.Red:
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.red);
                        player.Load();
                        player.Play();
                        break;
                    }
            }
        }


        public void disable_buttons()
        {
            Blue_button.Enabled = false;
            Yellow_button.Enabled = false;
            Green_button.Enabled = false;
            Red_button.Enabled = false;
        }

        public void enable_buttons()
        {
            Blue_button.Enabled = true;
            Yellow_button.Enabled = true;
            Green_button.Enabled = true;
            Red_button.Enabled = true;
        }

        public void change_back_color()
        {
            Blue_button.Image = Properties.Resources.blue1;
            Yellow_button.Image = Properties.Resources.yellow1;
            Green_button.Image = Properties.Resources.green1;
            Red_button.Image = Properties.Resources.red1;
        }

       
        private void timerIA_Tick(object sender, EventArgs e) //when timer is enabled, this method will be executed every 400 miliseconds
        {
            ai.IA_logic(this);
        }

        private void Start_button_Click(object sender, EventArgs e) //Here is the button start
        {
            Start_game();
        }

        private void Blue_button_MouseDown(object sender, MouseEventArgs e)
        {
            Button_action(Blue_button);
        }

        private void Blue_button_MouseUp(object sender, MouseEventArgs e)
        {
            Blue_button.Image = Properties.Resources.blue1;
            gamer.actual_pressed_color = B_Colors.Blue;
            gamer.gamer_turn(ai, this);
        }

        private void Yellow_button_MouseDown(object sender, MouseEventArgs e)
        {
            Button_action(Yellow_button);
        }

        private void Yellow_button_MouseUp(object sender, MouseEventArgs e)
        {
            Yellow_button.Image = Properties.Resources.yellow1;
            gamer.actual_pressed_color = B_Colors.Yellow;
            gamer.gamer_turn(ai, this);
        }

        private void Green_button_MouseDown(object sender, MouseEventArgs e)
        {
            Button_action(Green_button);
        }

        private void Green_button_MouseUp(object sender, MouseEventArgs e)
        {
            Green_button.Image = Properties.Resources.green1;
            gamer.actual_pressed_color = B_Colors.Green;
            gamer.gamer_turn(ai, this);
        }

        private void Red_button_MouseDown(object sender, MouseEventArgs e)
        {
            Button_action(Red_button);
        }

        private void Red_button_MouseUp(object sender, MouseEventArgs e)
        {
            Red_button.Image = Properties.Resources.red1;
            gamer.actual_pressed_color = B_Colors.Red;
            gamer.gamer_turn(ai, this);
        }

    }

    public class Gamer
    {
        public bool entered_gamer_turn = false;
        public bool lost = false;
        public B_Colors actual_pressed_color;
        protected int pressed_index = 0;
        public int score = 0;
        public int highscore;

        public void gamer_turn(AI ai, Genius game)
        {

            if(pressed_index < ai.button_sequence.Count)
            {
                if (ai.button_sequence[pressed_index] == actual_pressed_color) //the button pressed must be equal the random button generated by AI 
                {
                    ++pressed_index;
                    if (pressed_index == ai.button_sequence.Count)
                    {
                        pressed_index = 0;  //Start another turn, the gamer have to press all the sequence again    
                        ++score;         //the gamer pass one turn, then the score is incremented
                        if(score > highscore)
                        {
                            game.binary_file.seek_file_beggining();
                            game.binary_file.write_file(score);
                            game.binary_file.seek_file_beggining();
                            game.binary_file.show_highscore(game);
                            play_highscore_song();
                        }
                        show_score(game);
                        ai.new_shine(game);
                    }
                }
                else
                    lost_message(game, ai);
            }
        }

        protected void play_highscore_song()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.pass_highscore);
            player.Load();
            player.Play();
        }

        public void lost_message(Genius game, AI ai)
        {
            game.disable_buttons();
            play_lose_song();
            DialogResult user_choice_play_again = MessageBox.Show("Play again?",
                "You lost ):",
                MessageBoxButtons.YesNo);
            if(user_choice_play_again == DialogResult.Yes) //if yes, reset score, enable start button and reset AI list to start another game
            {
                game.binary_file.close_file();
                game.Start_button.Enabled = true;
                ai.reset_list();
                pressed_index = 0;
                score = 0;
            }
            else
            {
                game.binary_file.close_file();
                Application.Exit();

            }
        }

        protected void play_lose_song()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.you_lose);
            player.Load();
            player.Play();
        }

        public void show_score(Genius game)
        {
            game.score_label.Text = "Score: " + score.ToString();
        }

    }

    public class AI
    {

        public List<B_Colors> button_sequence = new List<B_Colors>(); //Random button sequence produced by ia
        public int actual_color = 0;
        public Random random = new Random();


        public void reset_list()
        {
            button_sequence.Clear();
        }


        public void Random_Generator_Sequence()
        {
            int button;         

            button = random.Next(1, 5);     //generate one random button 

            switch(button)
            {
                case 1:
                    button_sequence.Add(B_Colors.Blue); //add this to the list of generated buttons 
                    break;
                case 2:
                    button_sequence.Add(B_Colors.Yellow); //add this to the list of generated buttons  
                    break;
                case 3:
                    button_sequence.Add(B_Colors.Green); //add this to the list of generated buttons  
                    break;
                case 4:
                    button_sequence.Add(B_Colors.Red); //add this to the list of generated buttons  
                    break;
            }
        }

        protected void sequence_shine(Genius game, B_Colors actual_button)
        {
             switch (actual_button)
               {
                   case B_Colors.Blue:
                       game.Button_action(game.Blue_button);
                       break;
                   case B_Colors.Yellow:
                       game.Button_action(game.Yellow_button);                        
                       break;
                   case B_Colors.Green:
                       game.Button_action(game.Green_button);                        
                       break;
                   case B_Colors.Red:
                       game.Button_action(game.Red_button);                        
                       break;
                }
        }



        public void IA_logic(Genius game)
        {
            game.disable_buttons();

            game.change_back_color();

            if(actual_color >= button_sequence.Count)
            {
                game.enable_buttons();
            
                actual_color = 0;

                game.timerAI.Enabled = false;
            }
            else
            {
                sequence_shine(game, button_sequence[actual_color]);
                actual_color++;                
            }
        }

        public void new_shine(Genius game)
        {
            Random_Generator_Sequence();
            game.timerAI.Enabled = true;
        }
    }

    public class BinaryFile
    {
        private const string file_name = "highscore";
        BinaryReader reader_file;
        BinaryWriter writer_file;
        FileStream binary_file_highscore;

        public void open_file(Genius game)
        {
            if (File.Exists(file_name))
            {
                try
                {
                    binary_file_highscore = new FileStream(file_name, FileMode.Open);
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error trying opening score file. Sorry, but highscore wont be recorded" + e, "Error");
                }
                if (binary_file_highscore != null)
                {
                    reader_file = new BinaryReader(binary_file_highscore);
                    writer_file = new BinaryWriter(binary_file_highscore);
                }
            }
            else
            {
                try
                {
                    binary_file_highscore = new FileStream(file_name, FileMode.CreateNew);
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error trying creating score file. Sorry, but highscore wont be recorded" + e, "Error");
                }

                if (binary_file_highscore != null)
                {
                    reader_file = new BinaryReader(binary_file_highscore);
                    writer_file = new BinaryWriter(binary_file_highscore);
                    game.binary_file.write_file(0);
                    game.binary_file.seek_file_beggining();
                }
            }
        }

        public int read_file()
        {
            if(binary_file_highscore != null)
            {
                return reader_file.ReadInt32();
            }
            else
            {
                return -1; //error value
            }
        }

        public void write_file(int number)
        {
            if (binary_file_highscore != null)
            {
                writer_file.Write(number);
            }
        }

        public void seek_file_beggining()
        {
            binary_file_highscore.Seek(0, SeekOrigin.Begin);
        }

        public void close_file()
        {
            binary_file_highscore.Close();
        }

        public void show_highscore(Genius game)
        {
            game.highscore_label.Text = "Highscore: " + game.binary_file.read_file().ToString();
        }

    }

}