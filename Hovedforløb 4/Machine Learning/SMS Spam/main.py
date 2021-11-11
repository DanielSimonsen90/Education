import pandas as panda


data = panda.read_csv("smsspamcollection/SMSSpamCollection.csv", sep=",")


def run_file_conversion():
    data_frame = panda.read_csv(filepath_or_buffer="smsspamcollection/SMSSpamCollection", sep="\t", names=["Category", "Text"])
    data_frame.to_csv(path_or_buf="smsspamcollection/SMSSpamCollection.csv", sep=",", index=False)


def filter_data_by_spam_type(spam_type): return data[data["Category"] == spam_type]


def get_percentage(spam_type): return str(int(filter_data_by_spam_type(spam_type).size / data.size * 100))


#def addBinaryColumn(combined):
#    combined["Binary"] = 


def combine_equally():
    ham = filter_data_by_spam_type("ham")
    spam = filter_data_by_spam_type("spam")

    minimum = min([ham.shape[0], spam.shape[0]])

    ham_cut = ham.sample(minimum)
    spam_cut = spam.sample(minimum)

    print(
        f"Ham Size: {ham_cut.shape[0]}\n"
        f"Spam Size: {spam_cut.shape[0]}\n"
        f"Minimum: {minimum}"
    )

    return panda.DataFrame([spam_cut, ham_cut])


def get_percentage_between_data():
    percent_ham = get_percentage("ham")
    percent_spam = get_percentage("spam")
    total = str(int(percent_ham) + int(percent_spam))
    print(
        f"Ham Percent: {percent_ham}%\n" +
        f"Spam Percent: {percent_spam}%\n" +
        f"Total Percent: {total}%"
    )


if __name__ == '__main__':
    #run_file_conversion()
    get_percentage_between_data()
    combined = combine_equally()
    #combined["Binary"] = combined["Category"].
    

