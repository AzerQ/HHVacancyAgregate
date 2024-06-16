CREATE VIEW IF NOT EXISTS VacancyFullInfo
AS
SELECT
    v.VacancyId,
    v.Name AS VacancyName,
    a.Name AS AreaName,
    e.Name AS EmployerName,
    v.HasTest,
    v.PublishedAt,
    v.ResponseLetterRequired,
    v.SalaryCurrency,
    v.SalaryFrom,
    v.SalaryTo,
    v.SalaryGross,
    v.SnippetRequirement,
    v.SnippetResponsibility,
    vt.Name AS VacancyTypeName,
    v.Url,
    v.AcceptTemporary,
    v.Address,
    v.AdvResponseUrl,
    v.Archived,
    v.Contacts,
    v.CreatedAt,
    v.ResponseUrl,
    s.Name AS ScheduleName,
    v.SortPointDistance,
    emp.Name AS EmploymentName,
    exp.Name AS ExperienceName,
    v.CountersResponses,
    v.CountersTotalResponses,
    v.HigherEducationMention,
    v.SalaryFromClear,
    v.SalaryToClear,
    v.SalaryMiddleClear,
    vd.Description AS VacancyDescription,
    GROUP_CONCAT(DISTINCT ks.Name) AS KeySkills,
    GROUP_CONCAT(DISTINCT pr.Name) AS ProfessionalRoles
FROM Vacancies v
LEFT JOIN Areas a ON v.AreaId = a.AreaId
LEFT JOIN Employers e ON v.EmployerId = e.EmployerId
LEFT JOIN Employments emp ON v.EmploymentId = emp.EmploymentId
LEFT JOIN Expirences exp ON v.ExperienceId = exp.ExperienceId
LEFT JOIN Schedules s ON v.ScheduleId = s.ScheduleId
LEFT JOIN VacancyTypes vt ON v.VacancyTypeId = vt.VacancyTypeId
LEFT JOIN VacancyDetail vd ON v.VacancyId = vd.VacancyId
LEFT JOIN KeySkillVacancyLinks ksvl ON v.VacancyId = ksvl.VacancyId
LEFT JOIN KeySkills ks ON ksvl.KeySkillId = ks.KeySkillId
LEFT JOIN ProfessionalRoleVacancyLinks prvl ON v.VacancyId = prvl.VacancyId
LEFT JOIN ProfessionalRoles pr ON prvl.ProfessionalRoleId = pr.ProfessionalRoleId
GROUP BY v.VacancyId
ORDER BY v.PublishedAt DESC;
