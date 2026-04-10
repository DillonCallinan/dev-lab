def get_digits(number: int) -> list[int]:
    number = abs(number)

    if number == 0:
        return [0]

    digits = []
    i = 1

    while i <= number:
        j = 10 * i
        digit = (i * (number // i) - j * (number // (j))) // i
        digits.append(digit)
        i = j

    digits.reverse()
    return digits


def is_palindromic(number: int) -> bool:
    digits = get_digits(number)

    # Double negation ensures that answers are rounded up, if applicable
    middle = -(-len(digits) // 2)

    for i in range(middle):
        if digits[i] != digits[-(i + 1)]:
            return False

    return True


def get_palindromes() -> dict[tuple[int, int], int]:
    palindromes: dict[tuple[int, int], int] = {}

    for i in range(999, 99, -1):

        for j in range(999, 99, -1):
            product = i * j
            if is_palindromic(product):
                palindromes[(i, j)] = product

            if i == j:
                break

    return palindromes


# region Workings


def print_palindromes() -> None:
    palindromes = get_palindromes()
    print(f"{len(palindromes)=}")
    for (i, j), p in palindromes.items():
        print(f"{p} = {i} x {j}")


def check_if_palindromes_are_in_order() -> None:
    palindromes = get_palindromes()

    a = [x for x in palindromes.values()]
    b = a.copy()

    b.sort(reverse=True)

    sum = 0

    for i in range(len(a)):
        if a[i] != b[i]:
            sum += 1

    print(len(a))
    print(sum)


# endregion


palindromes = get_palindromes()

ans = max(palindromes.values())

i, j = [key for key, value in palindromes.items() if value == ans][0]

print(f"{ans} = {i} x {j}")
