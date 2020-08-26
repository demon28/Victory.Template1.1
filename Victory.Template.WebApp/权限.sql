



SELECT * FROM Tright_User_Role tur


SELECT tr.* FROM Tright_Role tr;

SELECT * FROM Tright_Role_Power trp

SELECT tp.* FROM Tright_Power tp;

SELECT * FROM Tright_Power_Menu tpm;

SELECT * FROM  Tright_Menu tm;



SELECT * FROM Tsys_User tu

SELECT * FROM  Tright_Group tg

SELECT * FROM Tright_User_Group tug

SELECT * FROM Tright_Group_Role tgr




SELECT m.* FROM
(
SELECT
  tu.Id Userid,
  tu.Name UserName,
  tu.Workid,
  tr.Id Roleid,
  tr.Role_Name
  FROM  Tsys_User tu
  LEFT JOIN Tright_User_Role tur ON tu.Id=tur.User_Id
  LEFT JOIN Tright_Role tr ON tr.Id=tur.Role_Id WHERE tr.Id!=''

 UNION 

  SELECT
    tu.Id,
    tu.Name UserName,
    tu.Workid,
   
    tr.Id Roleid,
    tr.Role_Name 
    FROM   Tsys_User tu
    LEFT JOIN Tright_User_Group tug ON tu.Id=tug.User_Id
    LEFT JOIN Tright_Group tg ON tg.Id=tug.Group_Id
    LEFT JOIN Tright_Group_Role tgr ON tgr.Group_Id=tg.Id
    LEFT JOIN Tright_Role tr ON tr.Id=tgr.Role_Id  WHERE tr.id!=''
) m  



  SELECT
   DISTINCT tm.Id MenuId,
 

    tm.Menu_Name,
    tm.Menu_Url,
    tm.Parent_Id,
    tm.Status,
    tm.Icon,
    tm.SortId
   
    FROM  Vright_UserRole vur
    
    LEFT JOIN Tright_Role_Power trp ON vur.Roleid=trp.Role_Id
    LEFT JOIN Tright_Power tp ON tp.Id=trp.Power_Id
    LEFT JOIN Tright_Power_Menu tpm ON tpm.Power_Id=tp.Id
    LEFT JOIN Tright_Menu tm ON tm.Id=tpm.Menu_Id

    WHERE  tp.id='1' and vur.userid='3'
