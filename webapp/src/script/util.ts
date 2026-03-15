export default class Util {
    constructor() {

    }
    /**
     * 将 HTML 颜色字符串（如 "#447090"）转换为 Phaser 需要的数字色值
     */
    static ToColor(htmlColor: string): number {
        // 去掉 # 号
        if (htmlColor.startsWith('#')) {
            htmlColor = htmlColor.slice(1);
        }
        // 支持 #RGB 简写
        if (htmlColor.length === 3) {
            htmlColor = htmlColor.split('').map((c: string) => c + c).join('');
        }
        // 转为数字
        return parseInt(htmlColor, 16);
    }
}