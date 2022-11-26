import pandas as pd
from pandas.core.frame import DataFrame
import seaborn as sns
import matplotlib.pylab as plt


def drop_dumb_columns(data: DataFrame): 
    return data.drop([
        "Unnamed: 0", "matchId",                # Serve no purpose
        "redDragonKills", "blueDragonKills",    # colorDragonKills have no data
        "blueAvgLevel", "redAvgLevel"           # colorAvgLevel is useless with the numbers received
    ], axis=1)


def get_color_data(data: DataFrame, color: str):
    # colornt = color == red ? "blue" : "red";
    colornt = "blue" if color == 'red' else "red"
    towers_destroyed = f"{colornt}TowersDestroyed"
    color_data = data.filter(regex=color).drop(f"{color}TowersDestroyed", axis=1)

    return pd.concat([color_data, data[towers_destroyed]], axis=1)


def get_data(color: str, type: str, filter: str):
    # Drops: Unamed: 0, matchId, bluedragonKills, redDragonKills, blueAvgLevel, redAvgLevel
    data = drop_dumb_columns(pd.read_csv("MatchTimelinesFirst15.csv", sep=","))

    # Filter "data" to match color restraint, if any 
    if color == 'red': data = get_color_data(data, "red")
    elif color == 'blue': data = get_color_data(data, "blue")

    # Filter data by "filter" param
    if filter != "": data = data.filter(regex=filter)

    # Show specific diagram type - heatmap is default
    if type == 'boxplot': sns.boxplot(data=data)
    elif type == 'histogram': data.hist()
    else: sns.heatmap(data.corr(), vmin=-1, vmax=1, annot=True, fmt=".2f")

    # Show selected diagram
    return plt.show()

get_data(
    color="",           # red | blue - all
    type="",            # boxplot | histogram - heatmap
    filter="",          # regex filter
)
