def fibonacci(n):
    sequence = [0, 1]
    for _ in range(n - 2):
        sequence.append(sequence[-1] + sequence[-2])
    return sequence

if __name__ == "__main__":
    print(fibonacci(10))  # Genererar de första 10 Fibonacci-talen
