<?php
include "Classes/Database.php";

$array = [];

$conn = (new Database)->Connect();
$sql = "SELECT * FROM `vraag`";

$stmt= $conn->prepare($sql);
$stmt->execute();

if ($stmt->rowCount() > 0) {
    http_response_code(200);

    foreach ($stmt->fetchAll() as $result) {
        $result["antwoorden"] = GetAnswers($result['vraag_id']);
        array_push($array, $result);
    }
}
else {
    http_response_code(404);
    $array = [ "message" => "geen resultaten", ];
}

function GetAnswers($id) {
    $answers = [];

    $conn = (new Database)->Connect();
    $sql = "SELECT * FROM `antwoord` WHERE `vraag_id` = $id";

    $stmt= $conn->prepare($sql);
    $stmt->execute();

    if ($stmt->rowCount() > 0) {
        $answers = $stmt->fetchAll();
    } else {
        $answers = NULL;
    }

    return $answers;
}

echo json_encode($array);