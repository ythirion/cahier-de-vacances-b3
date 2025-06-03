<?php

use Shift\Vertical;

it('returns the correct floor number based on instructions', function (string $fileName, int $expectedFloor) {
    $instructions = file_get_contents(__DIR__ . "/shifts/$fileName.txt");
    $result = Vertical::whichFloor($instructions);
    expect($result)->toBe($expectedFloor);
})->with([
    ['1', 0],
    ['2', 3],
    ['3', -1],
    ['4', 53],
    ['5', -3],
    ['6', 2920]
]);

