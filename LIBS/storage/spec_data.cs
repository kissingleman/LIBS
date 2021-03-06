﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LIBS.storage
{

    //设备设置
    //   积分时间、平均次数、平滑宽度、暗电流矫正
    /*****************************/
    //选择元素序列(选择顺序)
    [Serializable]
    public class select_element
    {
        public int sequece_index;
        public string element;
        public string label;
        public double select_wave;
        public double peak_wave;       //实际读取波长
        public double seek_peak_range; //硬件设备确定的情况下,某个波长的偏移也确定，寻峰和找积分区间可以和波长绑定
        public double interval_start;  //积分区间开始和结束
        public double interval_end;
        public int danwei;//1-ppm,2-ppb,3-%
    }
    //标样序列
    [Serializable]
    public class standard
    {
        public int standard_index; // 0号位置留给空白标样
        public string standard_label;
        public double[] standard_ppm;
        public int average_times;
        public bool is_readed;
    }

    //样本序列
    [Serializable]
    public class sample
    {
        public int sample_index;
        public string sample_label;
        public int average_times;
        public bool is_read;
        public int weight; //以下目前没用到
        public int volume;
        public int coefficient;
    }
    /************************************/
    //元数据
    //2048==pixel_of_channel && 10418==all_pixel_of_device
    //read_wave_all[10418] <= channel_wave[2048]
    //read_spec_all_now[10418] <= channel_spec[6][2048]
    //env_spec[10418]
    //read_standard_spec[x][ave_times][10418] => average_standard_spec
    //read_sample_spec[x][ave_times[10418] => average_sample_spec

    //程序中流动的数据对象，
    [Serializable]
    public class spec_metadata
    {
        public select_element[] elements; //简单的预定义大小以分配空间
        public standard[] standards;
        public sample[] samples;
        public double[] read_wave_all;
        public double[] read_spec_all_now;
        public double[] env_spec;
        public double[,,] read_standard_spec;
        public double[,,] read_sample_spec;
        public int element_cnt;  //通过cnt计数来标识实际使用的
        public int standard_cnt;
        public int sample_cnt;
    }

}
