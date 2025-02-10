import os

FOLDER = "C:/Users/Adam/Desktop/temp"  # Byt ut

def clean_folder():
    for filename in os.listdir(FOLDER):
        if filename.endswith((".tmp", ".log", ".bak")):
            os.remove(os.path.join(FOLDER, filename))
            print(f"Deleted: {filename}")

if __name__ == "__main__":
    clean_folder()
