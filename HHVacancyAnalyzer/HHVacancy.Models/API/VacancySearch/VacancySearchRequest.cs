namespace HHVacancy.Models.API.VacancySearch
{
    /// <summary>
    /// Модель запроса для поиска вакансий.
    /// </summary>
    public class VacancySearchRequest
    {
        /// <summary>
        /// Получить представление модели в виде словаря для QueryString параметров запроса
        /// </summary>
        /// <returns>Представление модели в виде словаря</returns>
        public Dictionary<string, object> ToDictionary()
        {
            var request = this;

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            // Преобразуем параметры запроса в словарь
            var queryParams = new Dictionary<string, object>
                {
                    { "page", request.Page },
                    { "per_page", request.PerPage },
                    { "search_field", request.SearchField != null ? string.Join(",", request.SearchField) : null },
                    { "experience", request.Experience != null ? string.Join(",", request.Experience) : null },
                    { "employment", request.Employment != null ? string.Join(",", request.Employment) : null },
                    { "schedule", request.Schedule != null ? string.Join(",", request.Schedule) : null },
                    { "area", request.Area != null ? string.Join(",", request.Area) : null },
                    { "metro", request.Metro != null ? string.Join(",", request.Metro) : null },
                    { "professional_role", request.ProfessionalRole != null ? string.Join(",", request.ProfessionalRole) : null },
                    { "industry", request.Industry != null ? string.Join(",", request.Industry) : null },
                    { "employer_id", request.EmployerId != null ? string.Join(",", request.EmployerId) : null },
                    { "currency", request.Currency },
                    { "salary", request.Salary },
                    { "label", request.Label != null ? string.Join(",", request.Label) : null },
                    { "only_with_salary", request.OnlyWithSalary },
                    { "period", request.Period },
                    { "date_from", request.DateFrom },
                    { "date_to", request.DateTo },
                    { "top_lat", request.TopLat },
                    { "bottom_lat", request.BottomLat },
                    { "left_lng", request.LeftLng },
                    { "right_lng", request.RightLng },
                    { "order_by", request.OrderBy },
                    { "sort_point_lat", request.SortPointLat },
                    { "sort_point_lng", request.SortPointLng },
                    { "clusters", request.Clusters },
                    { "describe_arguments", request.DescribeArguments },
                    { "no_magic", request.NoMagic },
                    { "premium", request.Premium },
                    { "responses_count_enabled", request.ResponsesCountEnabled },
                    { "part_time", request.PartTime != null ? string.Join(",", request.PartTime) : null },
                    { "accept_temporary", request.AcceptTemporary },
                    { "locale", request.Locale },
                    { "host", request.Host },
                    { "text", request.Text }
                }
            .Where(kv => kv.Value != null)  // Убираем параметры со значением null
            .ToDictionary(kv => kv.Key, kv => kv.Value);

#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            return queryParams;

        }

        /// <summary>
        /// Получение словаря с перезаписанными параметрами запроса
        /// </summary>
        /// <param name="overrideParams">Параметры для переопределения</param>
        /// <returns>Словарь с преопределенными значениями</returns>
        public Dictionary<string, object> ToDictionary(Dictionary<string, object> overrideParams)
        {
            Dictionary<string, object> paramsDictionary = ToDictionary();

            IEnumerable<KeyValuePair<string, object>> existingParms =
                overrideParams.Where(kv => paramsDictionary.ContainsKey(kv.Key));

            foreach (var existingParam in existingParms)
            {
                paramsDictionary[existingParam.Key] = existingParam.Value;
            }
            return paramsDictionary;
        }

        /// <summary>
        /// Преобразовать в словарь параметров запроса, с перезаписанной пагинацией
        /// </summary>
        /// <param name="pageNumber">Номер страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <returns>Словарь с параметрами запроса</returns>
        public Dictionary<string, object> ToDictionary(int pageNumber, int pageSize)
        {
            var newParams = new Dictionary<string, object>()
                {{ "page", pageNumber },{ "per_page" ,pageSize }};

            return ToDictionary(newParams);
        }

        /// <summary>
        /// Номер страницы.
        /// </summary>

        public int Page { get; set; } = 0;

        /// <summary>
        /// Количество элементов на странице.
        /// </summary>

        public int PerPage { get; set; } = 10;

        /// <summary>
        /// Область поиска. Возможные значения берутся из справочника vacancy_search_fields в /dictionaries.
        /// </summary>

        public List<string>? SearchField { get; set; }

        /// <summary>
        /// Опыт работы. Id из справочника experience в /dictionaries.
        /// </summary>

        public List<string>? Experience { get; set; }

        /// <summary>
        /// Тип занятости. Id из справочника employment в /dictionaries.
        /// </summary>

        public List<string>? Employment { get; set; }

        /// <summary>
        /// График работы. Id из справочника schedule в /dictionaries.
        /// </summary>

        public List<string>? Schedule { get; set; }

        /// <summary>
        /// Регион. Id из справочника /areas.
        /// </summary>

        public List<string>? Area { get; set; }

        /// <summary>
        /// Ветка или станция метро. Id из справочника /metro.
        /// </summary>

        public List<string>? Metro { get; set; }

        /// <summary>
        /// Профессиональная область. Id из справочника /professional_roles.
        /// </summary>

        public List<string>? ProfessionalRole { get; set; }

        /// <summary>
        /// Индустрия компании, разместившей вакансию. Id из справочника /industries.
        /// </summary>

        public List<string>? Industry { get; set; }

        /// <summary>
        /// Идентификатор работодателя.
        /// </summary>

        public List<string>? EmployerId { get; set; }

        /// <summary>
        /// Код валюты. Возможные значения берутся из справочника currency (ключ code) в /dictionaries.
        /// </summary>

        public string? Currency { get; set; }

        /// <summary>
        /// Размер заработной платы. Если указано это поле, но не указано currency, то для currency используется значение RUR.
        /// </summary>

        public int? Salary { get; set; }

        /// <summary>
        /// Фильтр по меткам вакансий. Id из справочника vacancy_label в /dictionaries.
        /// </summary>

        public List<string>? Label { get; set; }

        /// <summary>
        /// Показывать вакансии только с указанием зарплаты. По умолчанию false.
        /// </summary>

        public bool? OnlyWithSalary { get; set; }

        /// <summary>
        /// Количество дней, в пределах которых производится поиск по вакансиям.
        /// </summary>

        public int? Period { get; set; }

        /// <summary>
        /// Дата, которая ограничивает снизу диапазон дат публикации вакансий. Формат ISO 8601.
        /// </summary>

        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата, которая ограничивает сверху диапазон дат публикации вакансий. Формат ISO 8601.
        /// </summary>

        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Верхняя граница широты. Необходимо передавать одновременно все четыре параметра гео-координат.
        /// </summary>

        public double? TopLat { get; set; }

        /// <summary>
        /// Нижняя граница широты. Необходимо передавать одновременно все четыре параметра гео-координат.
        /// </summary>

        public double? BottomLat { get; set; }

        /// <summary>
        /// Левая граница долготы. Необходимо передавать одновременно все четыре параметра гео-координат.
        /// </summary>

        public double? LeftLng { get; set; }

        /// <summary>
        /// Правая граница долготы. Необходимо передавать одновременно все четыре параметра гео-координат.
        /// </summary>

        public double? RightLng { get; set; }

        /// <summary>
        /// Сортировка списка вакансий. Возможные значения берутся из справочника vacancy_search_order в /dictionaries.
        /// </summary>
        public string? OrderBy { get; set; }

        /// <summary>
        /// Значение географической широты точки, по расстоянию от которой будут отсортированы вакансии.
        /// </summary>

        public double? SortPointLat { get; set; }

        /// <summary>
        /// Значение географической долготы точки, по расстоянию от которой будут отсортированы вакансии.
        /// </summary>

        public double? SortPointLng { get; set; }

        /// <summary>
        /// Возвращать ли кластеры для данного поиска. По умолчанию false.
        /// </summary>

        public bool? Clusters { get; set; }

        /// <summary>
        /// Возвращать ли описание использованных параметров поиска (массив arguments). По умолчанию false.
        /// </summary>

        public bool? DescribeArguments { get; set; }

        /// <summary>
        /// Если true — автоматическое преобразование вакансий отключено. По умолчанию false.
        /// </summary>

        public bool? NoMagic { get; set; }

        /// <summary>
        /// Если true — в сортировке вакансий будут учтены премиум вакансии. По умолчанию false.
        /// </summary>

        public bool? Premium { get; set; }

        /// <summary>
        /// Если true — дополнительное поле counters с количеством откликов для вакансии включено. По умолчанию false.
        /// </summary>

        public bool? ResponsesCountEnabled { get; set; }

        /// <summary>
        /// Вакансии для подработки. Возможные значения: все элементы из working_days, working_time_intervals, working_time_modes, part, project, accept_temporary.
        /// </summary>

        public List<string>? PartTime { get; set; }

        /// <summary>
        /// Если true — поиск происходит только по вакансиям временной работы. По умолчанию false.
        /// </summary>

        public bool? AcceptTemporary { get; set; }

        /// <summary>
        /// Идентификатор локали (см. Локализация).
        /// </summary>

        public string Locale { get; set; } = "RU";

        /// <summary>
        /// Доменное имя сайта (см. Выбор сайта).
        /// </summary>

        public string Host { get; set; } = "hh.ru";

        /// <summary>
        /// Текстовый запрос для поиска вакансий.
        /// </summary>

        public string? Text { get; set; }

        /// <summary>
        /// Ограничение на максимальное кол-во результатов (не более 2000)
        /// </summary>

        public int MaxResults { get; set; } = 2000;
    }
}
