<?php
session_start();
unset($_SESSION['username']);
echo "<script>window.location.href='login.php'; </script>";