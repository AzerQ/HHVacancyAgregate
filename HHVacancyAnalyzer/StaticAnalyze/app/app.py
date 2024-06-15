import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import OneHotEncoder

# Загрузка данных
data = pd.read_csv('hh_vacancies.csv')

# Удаление дубликатов и пропущенных значений
data.drop_duplicates(inplace=True)
data.dropna(subset=['SalaryFrom', 'Experience', 'KeySkills', 'Area', 'EmploymentType'], inplace=True)

# Приведение заработных плат к одной валюте (пример)
data['Salary'] = data[['SalaryFrom', 'SalaryTo']].mean(axis=1)

# Преобразование категориальных данных
encoder = OneHotEncoder()
encoded_features = encoder.fit_transform(data[['Area', 'EmploymentType', 'KeySkills']]).toarray()
encoded_df = pd.DataFrame(encoded_features, columns=encoder.get_feature_names_out(['Area', 'EmploymentType', 'KeySkills']))
data = pd.concat([data, encoded_df], axis=1)

# Удаление оригинальных категориальных столбцов
data.drop(['Area', 'EmploymentType', 'KeySkills'], axis=1, inplace=True)

# Разделение данных на обучающую и тестовую выборки
X = data.drop(['Salary'], axis=1)
y = data['Salary']
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)
