
SELECT 
    ks.Name AS SkillName,
    COUNT(ksvl.VacancyId) AS MentionCount
FROM 
    KeySkillVacancyLinks ksvl
JOIN 
    KeySkills ks ON ks.KeySkillId = ksvl.KeySkillId
GROUP BY 
    ks.Name
ORDER BY 
    MentionCount DESC
LIMIT 20;
