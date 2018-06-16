SELECT
	row_number() OVER (ORDER BY s.fn1 NULLS LAST) AS number,
	s.fn1 AS name,
	s.start_date AS start,
	e.end_date AS end,
	e.end_date - s.start_date AS duration
FROM
(
	SELECT
		to_timestamp(min(trxdateutc)) AS start_date,
		fullname AS fn1
	FROM rpt_alltrx
	WHERE eventname like '%{0}%'
		AND sourcename like '%{1}%'
		AND to_timestamp(trxdateutc) >= to_timestamp('{4}', 'YYYY-MM-DD')
		AND to_timestamp(trxdateutc) <= to_timestamp('{5}', 'YYYY-MM-DD')
	GROUP BY fullname
) AS s
LEFT JOIN
(
	SELECT
		to_timestamp(max(trxdateutc)) AS end_date,
		fullname AS fn2 +
	FROM rpt_alltrx
	WHERE eventname like '%{2}%'
		AND sourcename like '%{3}%'
		AND to_timestamp(trxdateutc) >= to_timestamp('{4}', 'YYYY-MM-DD') 
		AND to_timestamp(trxdateutc) <= to_timestamp('{5}', 'YYYY-MM-DD')
	GROUP BY fullname
) AS e
ON s.fn1 = e.fn2
ORDER BY name ASC;