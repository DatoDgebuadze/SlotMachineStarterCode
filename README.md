# Slot Machine Project
### This project is a simple slot machine game that is created using C# and the Windows Forms application. The game is played by spinning three reels and checking for winning combinations. The game starts with a balance of $25 and the player can spend money to play the game by clicking the "Spin" button. The winnings are then calculated based on the combination of symbols that appear on the reels and the winnings are added to the player's balance.

## Getting Started
### To run this project, you will need to have Visual Studio installed on your machine. Once you have Visual Studio installed, you can download the source code and open it in Visual Studio. You can then run the project by clicking on the "Start" button in Visual Studio.

## Understanding the Code
### The code for this project is written in C# and makes use of the Windows Forms application. The main class is the Form1 class, which is the main form that is displayed to the player. The form contains three PictureBox controls, which are used to display the images of the symbols on the reels. The images for the symbols are loaded from disk when the form is initialized.

### The code for spinning the reels is done in the rotateImages() function, which uses a random number generator to select the images that will be displayed on each reel. The winnings are calculated in the calculateWinnings() function, which checks the combination of symbols that appear on the reels and sets the winnings accordingly.

### The player's balance is kept track of using the currentBalanceLabel variable and the spinWinningsLabel variable is used to keep track of the winnings from each spin. The moneySpentLabel variable is used to keep track of how much money the player has spent.

# Conclusion
### This project is a simple example of how to create a slot machine game using C# and the Windows Forms application. The code provides a foundation for creating more advanced slot machine games by adding additional features and customizing the game play.