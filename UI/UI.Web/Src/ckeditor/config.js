/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';


    config.filebrowserImageUploadUrl = '/Admin/Blog/Upload'; // ͼƬ�ϴ�·��
    config.image_previewText = ' '; // ͼƬ��Ϣ���Ԥ�������ݵ��������ݣ�Ĭ����ʾCKEditor�Դ�������
    config.language = 'zh-cn';
    //�������Ƿ���Ա�����
    config.toolbarCanCollapse = true;
    //��������λ��
    config.toolbarLocation = 'top';//��ѡ��bottom
    //������Ĭ���Ƿ�չ��
    config.toolbarStartupExpanded = true;

    config.height = 500;

};
