export function getEventTime(eventDate) {
    let startTime = new Date(eventDate.start_time);
    let endTime = new Date(eventDate.end_time);
    let locale = 'en-EN';
    let dateFormatOptions = {
        day: 'numeric',
        month: 'long'
    };
    let timeFormatOptions = {
        hour: 'numeric',
        minute: 'numeric'
    };

    if (startTime.toLocaleDateString() === endTime.toLocaleDateString())
        return startTime.toLocaleDateString(locale, dateFormatOptions) + ' ' + startTime.toLocaleTimeString(locale, timeFormatOptions) + ' - ' + endTime.toLocaleTimeString(locale, timeFormatOptions);

    if (eventDate.start_time.substring(0, 7) == eventDate.end_time.substring(0, 7))
        return startTime.getDate() + ' - ' + endTime.getDate() + ' ' + startTime.toLocaleDateString(locale, {
            month: 'long'
        })

    return startTime.toLocaleDateString(locale, dateFormatOptions) + ' - ' + endTime.toLocaleDateString(locale, dateFormatOptions)
}