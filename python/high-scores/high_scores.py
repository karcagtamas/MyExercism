
def latest(scores):
    return scores[len(scores) - 1]


def personal_best(scores):
    max = scores[0]
    for value in scores:
        if max < value:
            max = value
    return max


def personal_top_three(scores):
