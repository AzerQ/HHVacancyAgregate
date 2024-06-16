-- Добавление флага наличия высшего образования
ALTER Table Vacancies
ADD COLUMN HigherEducationMention INT GENERATED ALWAYS AS (IIF(LOWER(SnippetRequirement) LIKE '%высш__%образование%', 1, 0));

-- Добавление вычисления размера начала диапозона ЗП после вычета налогов
ALTER TABLE Vacancies
ADD COLUMN SalaryFromClear REAL GENERATED ALWAYS AS (IIF(SalaryGross = 1, SalaryFrom * 0.87, SalaryFrom));

-- Добавление вычисления размера конца диапозона ЗП после вычета налогов
ALTER TABLE Vacancies
ADD COLUMN SalaryToClear REAL GENERATED ALWAYS AS (IIF(SalaryGross = 1, SalaryTo * 0.87, SalaryTo));

-- Добавление вычисления размера средней ЗП после вычета налогов
ALTER TABLE Vacancies
ADD COLUMN SalaryMiddleClear REAL GENERATED ALWAYS AS ((COALESCE(SalaryFromClear, 0) + COALESCE(SalaryToClear, 0)) / 2);