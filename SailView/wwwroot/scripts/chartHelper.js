
window.getCardinalDirection = function (angle) {
    const directions = ['N', 'NE', 'E', 'SE', 'S', 'SW', 'W', 'NW'];
    const index = Math.round(((angle %= 360) < 0 ? angle + 360 : angle) / 45) % 8;
    return directions[index];
}

window.windDirectionTooltipTemplate = function (args) {
    const windDirection = args.point.y;
    const cardinalDirection = getCardinalDirection(windDirection);
    const tooltipText = `Wind Direction: ${windDirection.toFixed(0)}° (${cardinalDirection})`;
    return tooltipText;
}

