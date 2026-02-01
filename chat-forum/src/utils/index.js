export function formatDate(date) {
    const options = { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit' };
    return new Intl.DateTimeFormat('zh-CN', options).format(date);
}

export function generateUniqueId() {
    return 'id-' + Math.random().toString(36).substr(2, 16);
}

export function scrollToBottom(element) {
    if (element) {
        element.scrollTop = element.scrollHeight;
    }
}