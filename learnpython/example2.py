from math import radians
import numpy as np
import matplotlib.pyplot as plt

# learn to add new package matplotlib
def example2():
    x = np.arange(0, radians(1800), radians(12))
    plt.plot(x, np.cos(x), 'b')
    plt.show()

example2()