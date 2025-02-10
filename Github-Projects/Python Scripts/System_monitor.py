import psutil
import time

CPU_THRESHOLD = 30  # Procent
MEMORY_THRESHOLD = 80  # Procent

def monitor_system():
    psutil.cpu_percent(interval=None)  # För att initiera mätning
    
    while True:
        cpu_usage = psutil.cpu_percent(interval=1)
        memory_usage = psutil.virtual_memory().percent
        
        if cpu_usage > CPU_THRESHOLD:
            print(f'ALERT: CPU usage is high ({cpu_usage}%)')

        if memory_usage > MEMORY_THRESHOLD:
            print(f'ALERT: Memory usage is high ({memory_usage}%)')

        time.sleep(5)  # Vänta 5 sekunder innan nästa kontroll

if __name__ == "__main__":
    monitor_system()
