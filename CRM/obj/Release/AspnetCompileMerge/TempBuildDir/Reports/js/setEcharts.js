var setEchartsPie = {
  color: ['#5E9CD3', '#EB7D3C', '#A5A5A5', '#FDBF2D', '#91c7ae', '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'],
  tooltip: {
    trigger: 'item',
    formatter: "{a} <br/>{b}: {c} ({d}%)"
  },
  legend: {
    orient: 'vertical',
    x: 20,
    y: 'top',
    textStyle: {
      fontSize: '14',
      color: '#fff'
    },
    icon: 'stack',
    itemWidth: 10,
    itemHeight: 10,
    data: [],// ['第一季度', '第二季度', '第三季度', '第四季度']
  },
  series: [
    {
      name:'',//'税收收入',
      type: 'pie',
      radius: ['70%', '90%'],
      center: ['75%', '50%'],
      avoidLabelOverlap: false,
      label: {
        normal: {
          show: false,
          position: 'center'
        },
        emphasis: {
          show: true,
        }
      },
      labelLine: {
        normal: {
          show: false
        }
      },
      itemStyle: {
        borderWidth: 2,
        borderColor: '#fff',
      },
      data: [],
      // [
      //   {value: 335, name: '第一季度'},
      //   {value: 310, name: '第二季度'},
      //   {value: 234, name: '第三季度'},
      //   {value: 135, name: '第四季度'},
      // ]
    }
  ]
};

var setEchartsPie2 = {
  color: ['#5E9CD3', '#EB7D3C', '#A5A5A5', '#FDBF2D', '#91c7ae', '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'],
  tooltip: {
    trigger: 'item',
    formatter: "{a} <br/>{b}: {c} ({d}%)"
  },
  legend: {
    orient: 'vertical',
    x: 20,
    y: 'center',
    textStyle: {
      fontSize: '14',
      color: '#fff',
    },
    icon: 'stack',
    itemWidth: 10,
    itemHeight: 10,
    data: [],//['第一季度', '第二季度', '第三季度', '第四季度']
  },
  series: [
    {
      name: '',//'税收收入',
      type: 'pie',
      radius: ['0', '98%'],
      center: ['73%', '50%'],
      avoidLabelOverlap: false,
      label: {
        normal: {
          show: false,
          position: 'center'
        },
        emphasis: {
          show: true,
        }
      },
      labelLine: {
        normal: {
          show: false
        }
      },
      itemStyle: {
        borderWidth: 2,
        borderColor: '#fff',
      },
      data: [],
      // [
      //   {value: 335, name: '第一季度'},
      //   {value: 310, name: '第二季度'},
      //   {value: 234, name: '第三季度'},
      //   {value: 135, name: '第四季度'},
      // ]
    }
  ]
};

var setEchartsPie3 = {
  color: ['#5E9CD3', '#EB7D3C', '#A5A5A5', '#FDBF2D', '#91c7ae', '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'],
  tooltip: {
    trigger: 'item',
    formatter: "{a} <br/>{b}: {c} ({d}%)"
  },
  legend: {
    x: 'center',
    y: 'bottom',
    textStyle: {
      fontSize: '14',
      color: '#fff',
    },
    icon: 'stack',
    itemWidth: 10,
    itemHeight: 10,
    data:['第一季度', '第二季度', '第三季度', '第四季度']
  },
  series: [
    {
      name:'税收收入',
      type: 'pie',
      radius: ['0', '65%'],
      center: ['50%', '50%'],
      avoidLabelOverlap: false,
      label: {
        show: true,
        formatter:"{c},\n {d}%",
        color:'#fff',
      },
      labelLine: {
        length:10,
        length2:10,
        position:'left',
        lineStyle:{
          color:'#999'
        }
      },
      itemStyle: {
        borderWidth: 2,
        borderColor: '#fff',
      },
      data:
      [
        {value: 335, name: '第一季度'},
        {value: 310, name: '第二季度'},
        {value: 234, name: '第三季度'},
        {value: 135, name: '第四季度'},
      ]
    }
  ]
};

var setEchartsPie4 = {
  color: ['#5E9CD3', '#EB7D3C', '#A5A5A5', '#FDBF2D', '#91c7ae', '#749f83', '#ca8622', '#bda29a', '#6e7074', '#546570', '#c4ccd3'],
  tooltip: {
    trigger: 'item',
    formatter: "{a} <br/>{b}: {c} ({d}%)"
  },
  legend: {
    orient: 'vertical',
    // x: 20,
    // y: 'top',
    x: 'center',
    y: 'bottom',
    textStyle: {
      fontSize: '14',
      color: '#fff',
    },
    icon: 'stack',
    itemWidth: 10,
    itemHeight: 10,
    data:['第一季度', '第二季度', '第三季度', '第四季度']
  },
  series: [
    {
      name:'税收收入',
      type: 'pie',
      radius: ['0', '45%'],
      center: ['55%', '40%'],
      avoidLabelOverlap: false,
      label: {
        show: true,
        formatter:"{c},\n {d}%",
        color:'#fff',
      },
      labelLine: {
        length:10,
        length2:10,
        position:'left',
        lineStyle:{
          color:'#999'
        }
      },
      itemStyle: {
        borderWidth: 2,
        borderColor: '#fff',
      },
      data:
        [
          {value: 335, name: '第一季度'},
          {value: 310, name: '第二季度'},
          {value: 234, name: '第三季度'},
          {value: 135, name: '第四季度'},
        ]
    }
  ]
};


var setEchartsGauge = {

  tooltip: {
    formatter: "{a} <br/>{b} : {c}%"
  },

  series: [
    {
      name: '',//'业务指标',
      type: 'gauge',
      center: ['50%', '70%'],
      radius: '100px',
      startAngle: 180,
      endAngle: 0,
      axisLine: {
        lineStyle: {//轴线样式
          color: [[0.2, '#D74987'], [0.8, '#F1CD14'], [1, '#079950']],
          width: 15,
        },
      },
      splitLine: {           // 分隔线
        show: true,
        splitNumber: 1,
        length: 20,
        lineStyle: {
          width: 1,
          color: 'auto'
        }
      },
      axisLabel: {
        color: '#fff',
      },
      axisTick: {
        show: false,
      },
      pointer: {//指针
        width: 3
      },
      itemStyle: {//指针样式
        color: '#FEC400'
      },
      title: {
        color: 'transparent'
      },
      detail: {
        formatter: '完成{value}%',
        fontSize: 13,
        color: '#fff',
        offsetCenter: [0, '30%']
      },
      data: []// [{value: 41, name: '完成{value}%'}]
    }
  ]
};

var setEchartsLine = {
  color: ['#5E9CD3', '#EB7D3C'],
  tooltip: {
    trigger: 'axis'
  },
  grid: {
    left: 0,
    right: 0,
    top: '10%',
    bottom: '15%',
    containLabel: true
  },
  textStyle: {
    color: '#fff',
  },
  legend: {
    bottom: 0,
    icon: 'line',
    textStyle: {
      color: '#fff'
    },
    data: [],//['邮件营销sh', '搜索引擎'],
  },
  xAxis: {
    type: 'category',
    axisTick: {//刻度线不显示
      show: false
    },
    axisLine: {
      lineStyle: {color: '#fff'}
    },

    data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
  },
  yAxis: {
    type: 'value',
    axisTick: {//刻度线不显示
      show: false,
    },
    axisLabel: {//刻度文字加粗
      fontWeight: 'bold'
    },
    axisLine: {
      show: false
    },
    splitLine: {
      lineStyle: {color: '#fff'}
    },

  },
  series: [{
    name: '',//'邮件营销',
    data: [],//[820, 932, 901, 934, 1290, 1330, 1320],
    type: 'line',
    showSymbol: false
  },
    {
      name: '',//'搜索引擎',
      data: [],//[810, 732, 601, 234, 1190, 1370, 1320],
      type: 'line',
      showSymbol: false
    }]
};

