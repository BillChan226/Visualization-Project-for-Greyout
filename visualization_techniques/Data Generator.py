import os
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt
import warnings
from minisom import MiniSom
import numpy as np
import math
from sklearn.decomposition import PCA

index = 0
#for num in range(GreyOut_Num):

data = pd.read_csv('./Dataset/Whoop_then_Pull.csv')
#print(df)

# Dimensions
Temperature = []
Heart_rate = []
IOP = []
BP = []
SPO2 = []
Breath  = []
Time_Section = []
Y_acce = data['Y_acceleration']
X_velo = data['X_velocity']
Vertical_Speed = data['Vertical_Speed']
Yaw = data['Yaw']
Pitch = data['Pitch']
IAS  = data['IAS']

IOP = 14 + (Y_acce /(max(Y_acce) - min(Y_acce)))*0.5 + Pitch * 0.5 + np.random.rand(1)[0]*0.6 + X_velo * 0.01
Temperature = 36 + ((Vertical_Speed - min(Vertical_Speed)) / (max(Vertical_Speed) - min(Vertical_Speed)))*0.1 - X_velo * 0.005 + np.random.rand(1)[0]*0.05
BP = 110 + np.exp(((Y_acce- min(Y_acce)) /(max(Y_acce) - min(Y_acce)))) - (Y_acce /(max(Y_acce) - min(Y_acce))) * 20 + np.random.rand(1)[0] * 2
Breath = 15 + ((IAS- min(IAS)) /(max(IAS) - min(IAS))) + np.exp((Y_acce /(max(Y_acce) - min(Y_acce)))) + np.random.rand(1)[0]
SPO2 = 95 + ((BP- min(BP)) /(max(BP) - min(BP)))*3 - ((Breath- min(Breath))/(max(Breath) - min(Breath))) * 1 + np.random.rand(1)[0]*0.6
OPP = BP - IOP

data['IOP'] = IOP
data['Blood_Pressure'] = BP
data['Temperature'] = Temperature
data['Breath'] = Breath
data['SPO2'] = SPO2
data['OPP'] = OPP

data.to_csv('D:/demonstration_data.csv', encoding='utf_8_sig')

for t in data['Time']:
    if t < 3: Time_Section.append(3)
    if 3 <= t < 6: Time_Section.append(6)
    if 6 <= t < 9:Time_Section.append(9)
    if 9 <= t < 12:Time_Section.append(12)
    if 12 <= t < 15:Time_Section.append(15)
    if 15 <= t < 20:Time_Section.append(20)

data['Time_Section'] = Time_Section


pd.options.display.notebook_repr_html=False  # 表格显示
plt.rcParams['figure.dpi'] = 75  # 图形分辨率
sns.set_theme(style='darkgrid')  # 图形主题
sns.lineplot(data=data,x='Time',y='Y_acceleration', label = 'Y Acceleration')
sns.lineplot(data=data,x='Time',y='X_acceleration', label ='X Acceleration')
sns.lineplot(data=data,x='Time',y='Z_acceleration', label = 'Z Acceleration')
plt.show()

sns.lineplot(data=data,x='Time',y='Vertical_Speed', label = 'Vertical Speed')
plt.show()

sns.lineplot(data=data,x='Time',y='Y_velocity', label = 'Y Velocity')
sns.lineplot(data=data,x='Time',y='X_velocity', label ='X Velocity')
sns.lineplot(data=data,x='Time',y='Z_velocity', label = 'Z Velocity')
sns.lineplot(data=data,x='Time',y='IAS', label = 'Indicated Air Speed')
plt.show()

sns.lineplot(data=data,x='Time',y='Y_angular', label = 'Y Angular Velocity')
sns.lineplot(data=data,x='Time',y='X_angular', label ='X Angular Velocity')
sns.lineplot(data=data,x='Time',y='Z_angular', label = 'Z Angular Velocity')
plt.show()

sns.lineplot(data=data,x='Time',y='Pitch', label = 'Pitch')
sns.lineplot(data=data,x='Time',y='Bank', label ='Bank')
sns.lineplot(data=data,x='Time',y='Yaw', label = 'Yaw')
plt.show()

sns.lineplot(data=data,x='Time',y='IOP', label = 'IOP')
plt.show()

sns.lineplot(data=data,x='Time',y='OPP', label = 'OPP')
plt.show()

sns.lineplot(data=data,x='Time',y='Blood_Pressure', label = 'BP')
plt.show()

sns.lineplot(data=data,x='Time',y='Temperature', label = 'Temperature')
plt.show()

sns.lineplot(data=data,x='Time',y='SPO2', label = 'Oxygen saturation')
plt.show()

sns.lineplot(data=data,x='Time',y='Breath', label = 'Breath Rate')
plt.show()

sns.lineplot(data=data,x='Time',y='Greyout', label = 'Greyout Indicator')
plt.show()

data_pair = {'Pitch':(data['Pitch']-min(data['Pitch']))/(max(data['Pitch'])-min(data['Pitch'])),'Y_acceleration':(data['Y_acceleration']-min(data['Y_acceleration']))/(max(data['Y_acceleration'])-min(data['Y_acceleration'])), 'OPP':(data['OPP']-min(data['OPP']))/(max(data['OPP'])-min(data['OPP'])), 'X Velocity':(data['X_velocity']-min(data['X_velocity']))/(max(data['X_velocity'])-min(data['X_velocity'])), 'Time_Section':data['Time_Section']}
pair_data = pd.DataFrame(data_pair)
g = sns.pairplot(pair_data, hue='Time_Section')
g.map_lower(sns.kdeplot)
g.map_diag(sns.histplot)
g.map_upper(sns.scatterplot)
plt.show()

focus_data = data.iloc[650:950]
focus_data.rename(columns={'X_velocity':'Vx', 'Y_velocity':'Vy', 'Z_velocity':'Vz', 'X_angular':'Wx', 'Y_angular':'Wy', 'Z_angular':'Wz', 'X_acceleration':'Ax', 'Y_acceleration':'Ay', 'Z_acceleration':'Az', 'Blood_Pressure':'BP', 'Vertical_Speed':'VS', 'Temperature':'Temp'}, inplace=True)
del focus_data['Greyout']
del focus_data['Time']
del focus_data['Time_Section']
mat=focus_data.corr()
sns.heatmap(mat)
plt.show()

del focus_data['Vx']
del focus_data['Bank']
del focus_data['Az']
del focus_data['Temp']
del focus_data['Wx']

mat=focus_data.corr()
sns.heatmap(mat)
plt.show()


data_for_PCA = focus_data.to_numpy()

data_for_PCA = np.delete(data_for_PCA, 0, axis=1)
print(data_for_PCA)
pca = PCA(n_components=2)
pca.fit(np.array(data_for_PCA))

result=pca.transform(data_for_PCA)
print("variance", pca.explained_variance_ratio_)
w_x,  w_y = zip(*[d for d in result])
w_x = np.array(w_x)
w_y = -1 * np.array(w_y)
data_after_PCA = {'Wx':w_x, 'Wy':w_y}
Data_PCA = pd.DataFrame(data_after_PCA)
print("w_x", w_x)
print("w_y", w_y)
plt.figure(figsize = (8, 6))
sns.scatterplot(data=Data_PCA,x='Wx',y='Wy')

#focus_data.to_csv('D:/Flying_Around2_PCA.csv', encoding='utf_8_sig')
plt.grid()

plt.show()
