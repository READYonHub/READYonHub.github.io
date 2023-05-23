<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
  $name = $_POST["name"];
  $email = $_POST["email"];
  $subject = $_POST["subject"];
  $message = $_POST["message"];

  // E-mail küldése
  $to = "cím@example.com"; // A címzett e-mail címe
  $body = "Név: $name\nE-mail: $email\nTárgy: $subject\n\nÜzenet:\n$message";
  $headers = "From: $email";

  if (mail($to, $subject, $body, $headers)) {
    echo "Az e-mail sikeresen elküldve.";
  } else {
    echo "Az e-mail küldése sikertelen.";
  }
}
?>
