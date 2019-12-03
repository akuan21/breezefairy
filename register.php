<?php
	
	$con = mysqli_connect('localhost', 'root', 'root','unityaccess');

	 //check that connection happen
	 if(mysqli_connect_errno())
	 {
	 	echo "1: connection failed"; //error code #1= connecttion failed
	 	exit();
	 }

	 $username = $_POST["name"];
	 $password = $_POST["password"];


	 //doublechecking if this name exists. we dont want that query yapcaz
	 $namecheckquery = "SELECT username FROM players WHERE username = '". $username . "';";

	 $namecheck = mysqli_query($con, $namecheckquery) or die ("2: name check query failed"); //error coe #2 = name check query failed
	 if (mysqli_num_rows($namecheck) > 0)
	 {
	 	echo "3: name already exists"; //error code #3: name exists cannot register
	 	exit();
	 }

	 //add users to the table S H A 256 encyrtion. secure way to encrypt. . concat yapıyor
	 $salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
	 $hash = crypt($password, $salt);
	 $insertuserquery = "INSERT INTO players (username, hash, salt) VALUES ('". $username . "', '". $hash . "', '" . $salt . "');";
	 mysqli_query($con, $insertuserquery) or die("4: isert player query failed"); //error code #4: isert query failed

	 echo"0";




?>