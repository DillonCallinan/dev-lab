
series = set(y for x in (range(3, 1000, 3), range(5, 1000, 5)) for y in x)

ans = sum(series)

print(ans)
