<?php
 $query = "SELECT * FROM doctor ORDER BY Birthdate ASC;";
 $result = mysqli_query($connection,$query);
 if (!$result) {
  die("databases query failed.");
 }
 while ($row = mysqli_fetch_assoc($result)) {
 echo "<option>";
 echo "Id: " .$row["licensenum"]." Firstname: ".$row["firstname"]." Lastname: ".$row["l$
 " Licensedate: ".$row["licensedate"]." Birthdate: " .$row["birthdate"]." Hosworksat: "$
 " Speciality: ".$row["speciality"] ;
 echo "</option>";
 }
  mysqli_free_result($result);
?>


