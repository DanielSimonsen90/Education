from matplotlib.pyplot import axis
import pandas as pd
from pandas.core.frame import DataFrame
import seaborn as sns
import matplotlib.pylab as plt


def drop_dumb_columns(data: DataFrame):
    columns = ["Unnamed: 0", "matchId", "redDragonKills", "blueDragonKills"]
    return data.drop(columns, axis=1)


def get_color_data(data: DataFrame, color: str):
    # colornt = color == red ? "blue" : "red";
    colornt = "blue" if color == 'red' else "red"
    towers_destroyed = f"{colornt}TowersDestroyed"

    color_data = data.filter(regex=color)
    color_data = color_data.drop(f"{color}TowersDestroyed", axis=1)
    color_data = pd.concat([color_data, data[towers_destroyed]], axis=1)
    return color_data


#Drops: Unamed: 0, matchId, bluedragonKills, redDragonKills
data = drop_dumb_columns(pd.read_csv("MatchTimelinesFirst15.csv", sep=","))

blue_data = get_color_data(data, "blue")
red_data = get_color_data(data, "red")

# blue_data.heatmap = sns.heatmap(blue_data.corr(), vmin=-1, vmax=1, annot=True, fmt=".2f")
# red_data.heatmap = sns.heatmap(red_data.corr(), vmin=-1, vmax=1, annot=True, fmt=".2f")
heatmap = sns.heatmap(data.corr(), vmin=-1, vmax=1, annot=True, fmt=".2f")

# plt.figure(figsize=(blue_data.shape[1], blue_data.shape[1]))
plt.show()