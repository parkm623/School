<!DOCTYPE html> <html> <head>
        <title>Hospital Database</title>
        <link rel="stylesheet" type="text/css" href="hospital.css">
        <link href="https://fonts.googleapis.com/css?family=Mali" rel="stylesheet"> </head>
 <body>
 <?php
  include "connecttodb.php";
 ?>
 <h1>Hosptal Database </h1> Select database: <select>
  <option value="1">Doctors' specialties</option>
 <?php
  include "specialties.php";
 ?>
 </select>
 <form method="POST" action="hospital.php">
  Field:
  <input type="radio" value="Lastname" name="field">Lastname
  <input type="radio" value="Birthdate" name="field">Birthdate<br>
  Order:
  <input type="radio" value="Ascending" name="order">Ascending
  <input type="radio" value="Descending" name="order">Descending<br>
  <input type="submit" name="submit" value="Submit"><br>
 </form>
<?php
    if(isset($_POST['submit'])){
        if(isset($_POST["field"])&& ($_POST["field"] == "Lastname")){
            if(isset($_POST["order"]) && ($_POST["order"] == "Ascending")){
               include "gethospitalLA.php";}
            else if(isset($_POST["order"]) && ($_POST["order"] == "Descending")){
               include "gethospitalLD.php";}
            else{
               print "Select the order";}
        }else if(isset($_POST["field"])&& ($_POST["field"] == "Birthdate")){
            if(isset($_POST["order"]) && ($_POST["order"] == "Ascending")){
               include "gethospitalBA.php";}
            else if(isset($_POST["order"]) && ($_POST["order"] == "Descending")){
               include "gethospitalBD.php";}
            else{
               print "Select the order";}
        }else{
            print "Select the field";}
    }
?>
 <img src="http://www.csd.uwo.ca/~lreid/blendedcs3319/flippedclassroom/four/kids.png" width="216" height="260">
 <script src="hospital.js"> </script>
 </body>
 </html>
