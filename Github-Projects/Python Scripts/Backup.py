import shutil
import os

SOURCE_FOLDER = "C:/Users/Adam/Documents"  # Byt ut detta
BACKUP_FOLDER = "C:/Users/Adam/Backup"  # Byt ut detta

def backup_files():
    if not os.path.exists(BACKUP_FOLDER):
        os.makedirs(BACKUP_FOLDER)
    
    for filename in os.listdir(SOURCE_FOLDER):
        src_path = os.path.join(SOURCE_FOLDER, filename)
        dest_path = os.path.join(BACKUP_FOLDER, filename)
        
        if os.path.isfile(src_path):
            shutil.copy2(src_path, dest_path)
            print(f"Copied {filename} to backup folder.")

if __name__ == "__main__":
    backup_files()
