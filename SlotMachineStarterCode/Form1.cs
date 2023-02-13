using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SlotMachineStarterCode
{
    public partial class Form1 : Form
    {
        // global Variables
        
        // we want to access the timerCounter from multiple functions to run the spins
        int timerCounter;
        int moneySpentLabel;
        int currentBalanceLabel = 25;
        int spinWinningsLabel;

        // we need to declare image variables so that we can change fruit as we spin
        Image seven;
        Image lemon;
        Image grape;
        Image pineapple;

        // we need to keep track of the amount of money spent and the current balance
        // Declare those variables here!

        public Form1()
        {
            InitializeComponent();

            // Load my slot machine images from disk
            seven = Image.FromFile("../../Images/seven.png");
            grape = Image.FromFile("../../Images/grape.png");
            lemon = Image.FromFile("../../Images/lemon.png");
            pineapple = Image.FromFile("../../Images/pineapple.png");

            // we have 512 x 512 pixel images, make them fit the 128 x 128 pictureBoxes
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // Start all Images as seven
            pictureBox1.Image = seven;
            pictureBox2.Image = seven;
            pictureBox3.Image = seven;

        }

        private void setImage(PictureBox pb, int n)
        {
            switch (n)
            {
                case 1:
                    pb.Image = grape;
                    break;
                case 2:
                    pb.Image = lemon;
                    break;
                case 3:
                    pb.Image = seven;
                    break;
                case 4:
                    pb.Image = pineapple;
                    break;
            }
        }
        private void rotateImages()
        {
            Random rnd = new Random();
            setImage(pictureBox1, rnd.Next(1, 5));
            setImage(pictureBox2, rnd.Next(1, 5));
            setImage(pictureBox3, rnd.Next(1, 5));
        }

        // Hint C

        // void calculateWinnings()

        // We need to calculateWinnings, but we can do that by looking at the 
        // images in the pictureBoxes, we don't need a parameter
        
        //  We probably want a variable called 'winnings' to hold how much they won.

        // How do we know how much we won?

        // 3 sevens pays $25.  
        // if (pictureBox1.Image == seven) {
        //     // we know that we ended up with the 'seven' image in pictureBox one
        // }

        // So how do we know if all three pictureboxes are a 7?
        // Check all three.  If they are all a 7, then our winnings are 25.
        
        // 3 identical fruit pays $10
        // We can check to see if pictureBox1 and pictureBox2 have the same image:
        // if (pictureBox1.image == pictureBox2.image)
        // If pictureBox3 *also* has the same image, then all three are the same.
        // If all three images are the same, then we've won $10 -- unless we already 
        // won $25 because they are all seven.

        // Or, you could check to see if all images are the same *first*.  If they are, you've won either $10 or $25.
        // then, if all images are the same, see if the first image is seven, if so it is $25, if not it is $10

        // Any three fruit pays $1
        // How do we know if all three are fruit?
        // Let's get tricky.  There are four symbols, 3 fruit and a seven.
        // If *none* of the images are a seven, then we have to have 3 fruit, right?
        // Just make sure you only do *this* check if they haven't already won $25 for all sevens or $10 for identical fruit
        // set winnings = 1

        // Anything else $0  (the else part if you do all of this in an if - elseif - else statment
        // set winnings = 0

        // By the time you get here, you should know winnings

        // Hint F
        // Now we need to show their winnings and update their Balance.
        // Add the winnings to the current balance
        // update the currentBalanceLabel
        // update the winningsLabel





        private void spinButton_Click(object sender, EventArgs e)
        {

            // Hint G:

            // Does the player have enough money to spin?
            // If their currentBalance is at least 2, then yes, they do, no worries.
            // But if their currentBalance is less than that, then we want to stop.
            // First, we need to change the text of the warningLabel
            // Second, we need to stop.   Easiest way to do that is to return from the function.
            // Third, if we are going to *set* the warning label, we should probably *reset* the warning label
            // When should we reset the warning label?   When they restart (hint G1) or when they get enough money which can only happen if they add money (hint G2)

            // Start time and reset timerCounter
            timerCounter = 0;
            timer1.Interval = 100; // 100 ms or 1/10 of a second
            timer1.Start();
            if (currentBalanceLabel < 2)
            {
                MessageBox.Show("No sufficient funds on your accout! Need to add it!");

            }
            else
            {
                // Hint A:   the moment that the user clicks the spin Button,
                // it costs them $2, so we should update the currentBalance now
                moneySpentLabel = moneySpentLabel + 2;
                textBox1.Text = Convert.ToString(moneySpentLabel);
                currentBalanceLabel = currentBalanceLabel - 2;
                textBox2.Text = Convert.ToString(currentBalanceLabel);

            }


            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCounter += 1;

            // first 10 ticks are fast (1/10 of a second), second two are slower (400ms)
            if (timerCounter == 10)
            {
                timer1.Interval = 400;
            }

            if (timerCounter <= 12)
            {
                // rotate all the images every tick for the first 12 ticks
                rotateImages();
            }
            if (timerCounter > 12)
            {
                // stop the timer, we are done
                timer1.Stop();

                // Hint B
                // If the timer stops, the spin is over, we should calculate our winnings
                // call the calculateWinnings function
                pictureBox1.Image = seven;
                pictureBox2.Image = pineapple;
                pictureBox3.Image = pineapple;
                calculateWinnings();

            }
        }

        private void calculateWinnings()
        {
            if (pictureBox1.Image == seven && pictureBox2.Image == seven && pictureBox3.Image == seven)
            {
                currentBalanceLabel = currentBalanceLabel + 25;
                textBox2.Text = Convert.ToString(currentBalanceLabel);
                spinWinningsLabel = 25;
                textBox3.Text = Convert.ToString(spinWinningsLabel);
                if (pictureBox1.Image == seven && pictureBox2.Image == pineapple && pictureBox3.Image == pineapple)
                {
                    currentBalanceLabel = currentBalanceLabel + 0;
                    textBox2.Text = Convert.ToString(currentBalanceLabel);
                    spinWinningsLabel = 0;
                    textBox3.Text = Convert.ToString(spinWinningsLabel);
                }
            }
            else if (pictureBox1.Image == grape && pictureBox2.Image == grape && pictureBox3.Image == grape)
            {
                currentBalanceLabel = currentBalanceLabel + 10;
                textBox2.Text = Convert.ToString(currentBalanceLabel);
                spinWinningsLabel = 10;
                textBox3.Text = Convert.ToString(spinWinningsLabel);
            }
            else if (pictureBox1.Image == pineapple && pictureBox2.Image == pineapple && pictureBox3.Image == pineapple)
            {
                currentBalanceLabel = currentBalanceLabel + 10;
                textBox2.Text = Convert.ToString(currentBalanceLabel);
                spinWinningsLabel = 10;
                textBox3.Text = Convert.ToString(spinWinningsLabel);
            }
            else if (pictureBox1.Image == lemon && pictureBox2.Image == lemon && pictureBox3.Image == lemon)
            {
                currentBalanceLabel = currentBalanceLabel + 10;
                textBox2.Text = Convert.ToString(currentBalanceLabel);
                spinWinningsLabel = 10;
                textBox3.Text = Convert.ToString(spinWinningsLabel);
            }
            else if (pictureBox1.Image != seven && pictureBox2.Image != seven && pictureBox3.Image != seven)
            {
                currentBalanceLabel = currentBalanceLabel + 1;
                textBox3.Text = Convert.ToString(currentBalanceLabel);
                spinWinningsLabel = 1;
                textBox3.Text = Convert.ToString(spinWinningsLabel);
            }
            if (currentBalanceLabel < 2)
            {
                addMoneyButton.Visible = true;
                restartButton.Visible = true;

            }
            else
            {
                addMoneyButton.Visible = false;
                restartButton.Visible = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addMoneyButton_Click(object sender, EventArgs e)
        {
            currentBalanceLabel= currentBalanceLabel + 5;
            textBox2.Text= Convert.ToString(currentBalanceLabel);
            moneySpentLabel = moneySpentLabel+ 5;
            textBox1.Text = Convert.ToString(moneySpentLabel);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            currentBalanceLabel = 25;
            textBox2.Text = Convert.ToString(currentBalanceLabel);
            spinWinningsLabel = 0;
            textBox3.Text = Convert.ToString(spinWinningsLabel);
            moneySpentLabel = 0;
            textBox1.Text = Convert.ToString(moneySpentLabel);
        }

        // Hint D
        // addMoneyButton click handler
        // inside that function, you'll want to do four things
        // add 5 to the currentBalance
        // add 5 to the moneySpent
        // change the currentBalanceLabel
        // change the moneySpentLabel
        // Hint G2:  if you are using the warningLabel, we should turn that off because now they have enough money to spin.

        // Hint E
        // restartButton click handler
        // Need to reset the values of currentBalance and moneySpent to what we started with
        // Hint G1:  if you are using the warningLabel, we should turn that off too, because you start with enough money to spin.

    }                              
}
