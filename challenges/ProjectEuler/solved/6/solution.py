def sumotsquares(numbers: list[int]) -> int:
    return sum([pow(x, 2) for x in numbers])


def squareotsum(numbers: list[int]) -> int:
    return pow(sum(numbers), 2)


def main():
    r_1_10 = [x for x in range(1, 11)]
    assert squareotsum(r_1_10) - sumotsquares(r_1_10) == 2640

    r_1_100 = [x for x in range(1, 101)]
    x = sumotsquares(r_1_100)
    y = squareotsum(r_1_100)
    ans = y - x
    print(f"{y} - {x} = {ans}")


main()
