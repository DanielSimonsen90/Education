# Supervised Classification

import pandas as panda
import matplotlib.pyplot as plt

from pandas.core.frame import DataFrame
from sklearn.pipeline import Pipeline
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report
from sklearn.feature_extraction.text import CountVectorizer, TfidfTransformer
from sklearn.naive_bayes import MultinomialNB

data = panda.read_csv("smsspamcollection/SMSSpamCollection.csv", sep=",")


def run_file_conversion():
    data_frame = panda.read_csv(filepath_or_buffer="smsspamcollection/SMSSpamCollection", sep="\t", names=["Category", "Text"])
    data_frame.to_csv(path_or_buf="smsspamcollection/SMSSpamCollection.csv", sep=",", index=False)


def filter_data_by_spam_type(spam_type): return data[data["Category"] == spam_type]


def get_percentage(spam_type): return str(int(filter_data_by_spam_type(spam_type).size / data.size * 100))


def add_binary_column(combined: DataFrame):
    combined["Binary"] = combined["Category"].map(lambda c: 1 if c == 'spam' else 0)
    return combined

def combine_equally():
    ham = filter_data_by_spam_type("ham")
    spam = filter_data_by_spam_type("spam")

    minimum = min([ham.shape[0], spam.shape[0]])

    ham_cut = ham.sample(minimum)
    spam_cut = spam.sample(minimum)

    print(
        f"Ham Size: {ham_cut.shape[0]}\n"
        f"Spam Size: {spam_cut.shape[0]}\n"
        f"Minimum: {minimum}\n"
    )

    return panda.concat([spam_cut, ham_cut])


def get_percentage_between_data():
    percent_ham = get_percentage("ham")
    percent_spam = get_percentage("spam")
    total = str(int(percent_ham) + int(percent_spam))
    print(
        f"Ham Percent: {percent_ham}%\n" +
        f"Spam Percent: {percent_spam}%\n" +
        f"Total Percent: {total}%\n"
    )

def machine_learning_moment(combined: DataFrame):
    model = MultinomialNB()
    text, category = [combined['Text'], combined['Category']]
    x_train, x_test, y_train, y_test = train_test_split(text, category, test_size=.25, random_state=42, shuffle=True, stratify=category)
    pipeline_model = Pipeline([
        ('vect', CountVectorizer()), 
        ('tfidf', TfidfTransformer()),
        ('clf', model)
    ])

    pipeline_model.fit(x_train, y_train)
    print(f"Accuracy: {str(pipeline_model.score(x_test, y_test) * 100)}")

    y_predict = pipeline_model.predict(x_test)
    print(classification_report(y_test, y_predict))


if __name__ == '__main__':
    #run_file_conversion()
    get_percentage_between_data()
    combined = combine_equally()
    combined = add_binary_column(combined)
    # print(combined)
    machine_learning_moment(combined)
