class Matrix:
    M = []

    def __init__(self, matrix_string):
        M = []
        rows = matrix_string.split("\n")
        for row in rows:
            cells = row.split(" ")
            m = []
            for cell in cells:
                m.append(int(cell))
            M.append(m)

    def row(self, index):
        return M[index]

    def column(self, index):
        return M[index]
