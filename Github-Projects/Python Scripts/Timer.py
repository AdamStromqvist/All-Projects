import time

def countdown(seconds):
    while seconds:
        mins, secs = divmod(seconds, 60)
        timeformat = f'{mins:02}:{secs:02}'
        print(timeformat, end='\r')
        time.sleep(1)
        seconds -= 1
    
    print("Time's up!")

if __name__ == "__main__":
    countdown(10)  # Ändra 10 till önskad tid i sekunder
