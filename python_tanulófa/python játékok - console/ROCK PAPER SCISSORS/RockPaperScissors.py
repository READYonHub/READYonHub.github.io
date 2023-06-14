import random

def play_game():
    scorePlayer = 0
    scoreCPU = 0

    while scorePlayer < 3 and scoreCPU < 3:
        print("Choose between ROCK, PAPER, and SCISSORS:")
        inputPlayer = input().upper()

        randomInt = random.randint(1, 3)

        if randomInt == 1:
            inputCPU = "ROCK"
        elif randomInt == 2:
            inputCPU = "PAPER"
        else:
            inputCPU = "SCISSORS"

        print("Computer choose", inputCPU)

        if inputPlayer == inputCPU:
            print("DRAW!!!\n")
        elif (
            (inputPlayer == "ROCK" and inputCPU == "SCISSORS") or
            (inputPlayer == "PAPER" and inputCPU == "ROCK") or
            (inputPlayer == "SCISSORS" and inputCPU == "PAPER")
        ):
            print("PLAYER WINS!!!\n")
            scorePlayer += 1
        else:
            print("CPU WINS!!!\n")
            scoreCPU += 1

        print("SCORES:\tPLAYER:\t", scorePlayer, "\tCPU:\t", scoreCPU)

    if scorePlayer == 3:
        print("Player WON!!!")
    elif scoreCPU == 3:
        print("CPU WON!!!")

def main():
    playAgain = True

    while playAgain:
        play_game()

        loop = ""
        while loop != "y" and loop != "n":
            print("DO YOU WANT TO PLAY ONE MORE GAME? (y/n)")
            loop = input().lower()

            if loop == "y":
                playAgain = True
                print("\n")
            elif loop == "n":
                playAgain = False
            else:
                print("Invalid entry!")

if __name__ == "__main__":
    main()
