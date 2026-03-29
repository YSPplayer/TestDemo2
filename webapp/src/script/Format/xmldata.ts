export interface XmlNode {
    parent:XmlNode | null;
    data:any;
    children:XmlNode[];
    type:string;
}
export const filterKeys = ['body','div']