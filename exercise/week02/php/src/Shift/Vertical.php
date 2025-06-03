<?php

namespace Shift;

class Vertical
{
    public static function whichFloor(string $signalStream): int
    {
        $val = [];

        for ($i = 0; $i < strlen($signalStream); $i++) {
            $c = $signalStream[$i];

            if (strpos($signalStream, "🧝")) {
                $j = ($c === ')') ? 3 : -2;
                $val[] = [$c, $j];
            } else if (strpos($signalStream, "🧝") === false) {
                $val[] = [$c, ($c === '(') ? 1 : -1];
            } else {
                $val[] = [$c, ($c === '(') ? 42 : -2];
            }
        }

        $result = 0;
        foreach ($val as $kp) {
            $result += $kp[1];
        }

        return $result;
    }
}